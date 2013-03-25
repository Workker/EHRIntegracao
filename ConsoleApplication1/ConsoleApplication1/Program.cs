using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public static class AsyncInline
    {
        public static void Run(Func<Task> item)
        {
            var oldContext = SynchronizationContext.Current;
            var synch = new ExclusiveSynchronizationContext();
            SynchronizationContext.SetSynchronizationContext(synch);
            synch.Post(async _ =>
            {
                try
                {
                    await item();
                }
                catch (Exception e)
                {
                    synch.InnerException = e;
                    throw;
                }
                finally
                {
                    synch.EndMessageLoop();
                }
            }, null);
            synch.BeginMessageLoop();
            SynchronizationContext.SetSynchronizationContext(oldContext);
        }
        public static T Run<T>(Func<Task<T>> item)
        {
            var oldContext = SynchronizationContext.Current;
            var synch = new ExclusiveSynchronizationContext();
            SynchronizationContext.SetSynchronizationContext(synch);
            T ret = default(T);
            synch.Post(async _ =>
            {
                try
                {
                    ret = await
                    item();
                }
                catch (Exception e)
                {
                    synch.InnerException = e;
                    throw;
                }
                finally
                {
                    synch.EndMessageLoop();
                }
            }, null);
            synch.BeginMessageLoop();
            SynchronizationContext.SetSynchronizationContext(oldContext);
            return ret;
        }

        private class ExclusiveSynchronizationContext : SynchronizationContext
        {
            private bool done;
            public Exception InnerException { get; set; }
            readonly AutoResetEvent workItemsWaiting = new AutoResetEvent(false);
            readonly Queue<Tuple<SendOrPostCallback, object>> items =
             new Queue<Tuple<SendOrPostCallback, object>>();

            public override void Send(SendOrPostCallback d, object state)
            {
                throw new NotSupportedException("We cannot send to our same thread");
            }
            public override void Post(SendOrPostCallback d, object state)
            {
                lock (items)
                {
                    items.Enqueue(Tuple.Create(d, state));
                }
                workItemsWaiting.Set();
            }
            public void EndMessageLoop()
            {
                Post(_ => done = true, null);
            }
            public void BeginMessageLoop()
            {
                while (!done)
                {
                    Tuple<SendOrPostCallback, object> task = null;
                    lock (items)
                    {
                        if (items.Count > 0)
                        {
                            task = items.Dequeue();
                        }
                    }
                    if (task != null)
                    {
                        task.Item1(task.Item2);
                        if (InnerException != null) // the method threw an exeption
                        {
                            throw new AggregateException("AsyncInline.Run method threw an exception.",
                             InnerException);
                        }
                    }
                    else
                    {
                        workItemsWaiting.WaitOne();
                    }
                }
            }
            public override SynchronizationContext CreateCopy()
            {
                return this;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // var pacientesComS = AsyncInline.Run<List<PacienteDTO>>(() => ObterPacientes("S"));
            var pacientes = ObterPacientes("S",9000).ContinueWith(Finalizer);

            var pacientesNovos = ObterPacientes("T",0).ContinueWith(Finalizer);
            Console.ReadLine();
        }

        private static void Finalizer(Task<List<PacienteDTO>> task)
        {
            foreach (var item in task.Result)
            {
                Console.WriteLine(item.Nome);
            }
        }
        private static Task<List<PacienteDTO>> ObterPacientes(string nome,int num)
        {
            return Task<List<PacienteDTO>>.Factory.StartNew(() => GetPatient(nome,num));
        }

        private static List<PacienteDTO> GetPatient(string nome,int numero)
        {
            ServicoObterPacientes service = new ServicoObterPacientes();
            return service.ObterPaciente(nome,numero);
        }

    }

    public class PacienteDTO
    {
        public string Nome { get; set; }
    }

    public class ServicoObterPacientes
    {

        public List<PacienteDTO> ObterPaciente(string nome,int num)
        {
            List<PacienteDTO> pacientes = new List<PacienteDTO>();
            pacientes.Add(new PacienteDTO() { Nome = "Sammuel" });
            pacientes.Add(new PacienteDTO() { Nome = "Sammuel Garcia" });
            pacientes.Add(new PacienteDTO() { Nome = "Thiago" });
            pacientes.Add(new PacienteDTO() { Nome = "Thiago Oliveira" });
            Thread.Sleep(num);
            return pacientes.Where(n => n.Nome.Contains(nome)).ToList();
        }
    }

}
