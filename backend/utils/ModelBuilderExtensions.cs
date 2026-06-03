using Microsoft.EntityFrameworkCore;

namespace backend.utils
{
    public static class ModelBuilderExtensions
    {
        // TBase = your base class (ResourceGeneric)
        // TEnum = your enum type (UnitType)
        public static void AutoMapByEnum<TBase, TEnum>(
            this ModelBuilder modelBuilder,
            string dbColumnName,
            List<TBase> instances
        ) where TBase : class where TEnum : Enum
        {
            // 1. Tell EF Core what the column name is in the database
            var discriminator = modelBuilder.Entity<TBase>().HasDiscriminator<TEnum>(dbColumnName);

            // 2. Loop through your instances
            foreach (var instance in instances)
            {
                Type type = instance.GetType();

                // 3. Find the property inside the class that matches the Enum type
                var enumProperty = type.GetProperties()
                    .FirstOrDefault(p => p.PropertyType == typeof(TEnum));

                if (enumProperty != null)
                {
                    // 4. Extract the enum value (e.g., UnitType.L)
                    var enumValue = (TEnum)enumProperty.GetValue(instance)!;

                    // 5. Register it with EF Core
                    discriminator.HasValue(type, enumValue);
                }
            }
        }

        public static void AutoMapDerivedTypes<TBase, TDiscriminator>(
        this ModelBuilder modelBuilder,
        string columnName,
        List<TBase> instances) where TBase : class
        {
            // 1. Setup the discriminator on EF Core dynamically
            var discriminator = modelBuilder.Entity<TBase>().HasDiscriminator<TDiscriminator>(columnName);

            // 2. Loop through whatever list of instances you passed in
            foreach (var instance in instances)
            {
                Type type = instance.GetType();

                // 3. Use Reflection safely to grab the value of the property matching your column name
                var propertyInfo = type.GetProperty(columnName);
                if (propertyInfo != null)
                {
                    var value = (TDiscriminator)propertyInfo.GetValue(instance)!;
                    discriminator.HasValue(type, value);
                }
            }
        }
    }
}
