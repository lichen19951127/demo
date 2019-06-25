using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BestQA.Web.Extensions
{
    public class ModelErrorModel
    {
        public string Name { get; set; }
        public IEnumerable<string> Value { get; set; }
    }

    public class ModelStateHelpers
    {
        public static List<ModelErrorModel> GetModelStateErrors(ModelStateDictionary modelState)
        {
            return modelState.Where(state => state.Value.Errors.Any())
                .Select(state => new ModelErrorModel
                {
                    Name = state.Key,
                    Value = state.Value.Errors.Select(x => x.ErrorMessage).Concat(state.Value.Errors.Where(x => x.Exception != null).Select(x => x.Exception.Message))
                }).ToList();
        }   
    }
}