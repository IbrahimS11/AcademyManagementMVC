namespace Instructors.ViewModel.ValidationAttributes
{
    public class UniqueNameDeptAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string Name = value?.ToString() ?? string.Empty;
            if (Name is null)
            {
                return new ValidationResult("Name cannot be null");
            }
            int id = (int)validationContext.ObjectType.GetProperty("ID")!.GetValue(validationContext.ObjectInstance)!;
            AppDbContext context = new AppDbContext();

            Department? dept = context.Departments.FirstOrDefault(d => (d.Name == Name && d.ID != id));

            if (dept is not null)
            {
                return new ValidationResult(ErrorMessage ?? "Must be aunique.");
            }
            return ValidationResult.Success;
        }
    }
}
