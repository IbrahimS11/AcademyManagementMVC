using System.ComponentModel.DataAnnotations;

namespace Instructors.Models
{
    public class UniqueAttribute : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string  Name=value?.ToString() ?? string.Empty;
            if(Name is null)
            {
                return new ValidationResult("Name cannot be null");
            }
            int id= (int)validationContext.ObjectType.GetProperty("Id")!.GetValue(validationContext.ObjectInstance)!;
            AppDbContext context = new AppDbContext();


            Course? crs=context.Courses.FirstOrDefault(c=>(c.Name== Name&&c.Id!=id) );

            if(crs is not null)
            {
                return new ValidationResult(ErrorMessage ?? "Must be aunique.");
            }
            return ValidationResult.Success;

        }







        //override protected ValidationResult? IsValid(object? value, ValidationContext validationContext)
        //{
        //    var context = new AppDbContext();
        //    var entity = context.Set(validationContext.ObjectType).Find(value);
        //    if (entity != null)
        //    {
        //        return new ValidationResult($"{validationContext.DisplayName} must be unique.");
        //    }
        //    return ValidationResult.Success;
        //}
    }
}
