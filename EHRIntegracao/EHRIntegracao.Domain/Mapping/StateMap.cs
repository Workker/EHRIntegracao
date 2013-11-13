using EHR.CoreShared.Entities;

namespace EHRIntegracao.Domain.Mapping
{
    public class StateMap : ValueObjectMap<State>
    {
        StateMap()
        {
            Map(s => s.Acronym);
        }
    }
}
