using GraphQL.Types;
using HotChocolate.Types;

namespace FysioAPI.GraphQL.Types
{
    // public sealed class TreatmentTypeType : ObjectGraphType<Core.Domain.TreatmentType>
    // {
    //     // public TreatmentTypeType()
    //     // {
    //     //     Field(x => x.Id);
    //     //     Field(x => x.TreatmentCode);
    //     //     Field(x => x.Description);
    //     //     Field(x => x.ExplanationRequired);
    //     // }
    //     
    // }
    
    public class TreatmentType :ObjectType<Core.Domain.TreatmentType>{}

}