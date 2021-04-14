using System;

namespace LuceneExtensions.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IdProperty : Attribute
    {
        public static bool HasIdProperty<T>()
        {
            var props = typeof(T).GetProperties();

            var isDefined = false;

            foreach (var prop in props)
            {
                var propHasIdProperty = IsDefined(prop, typeof(IdProperty));

                if (isDefined && propHasIdProperty) throw new Exception("You can have only one ID property!");

                if (!isDefined && propHasIdProperty) isDefined = true;
            }

            return isDefined;
        }
        
        public static string GetIdPropertyName<T>()
        {
            if (HasIdProperty<T>())
            {
                var props = typeof(T).GetProperties();
                foreach (var prop in props)
                {
                    var propHasIdProperty = IsDefined(prop, typeof(IdProperty));
                    if (propHasIdProperty)
                    {
                        return prop.Name;
                    }
                }
            }

            throw new Exception("Class does not have ID property!");
        }

        public static TK GetIdValue<T, TK>(T obj)
        {
            var hasIdProperty = HasIdProperty<T>();

            if (hasIdProperty)
            {

                var props = typeof(T).GetProperties();

                foreach (var prop in props)
                {
                    var propHasIdProperty = IsDefined(prop, typeof(IdProperty));

                    if (propHasIdProperty)
                    {
                        var id = (TK) prop.GetValue(obj)!;
                        return id;
                    }
                }
            }
            
            throw new Exception("Class does not have ID property!");
        }
    }
}