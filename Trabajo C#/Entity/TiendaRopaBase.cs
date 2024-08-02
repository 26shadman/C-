using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Reflection;

namespace Tienda
{
    [Serializable]  // Indica que la clase puede ser serializada
    public class TiendaRopa
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [DefaultValue("infantil, dama, hombre, deportiva")]  // Especifica un valor predeterminado para la propiedad
        public string Category { get; set; }

        [Category("camisa, blusa, interior, pantalon, falda")]  // Especifica la categoría de la propiedad
        public string Type { get; set; }

        [Browsable(true)]  // Indica que la propiedad no debe ser visible en el diseñador
        public int Nit { get; set; }

        [Obsolete("Usa EmailAddress en lugar de esta propiedad.")]
        public string OldEmailAddress { get; set; }  // Ejemplo de propiedad obsoleta

        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Region { get; set; }

        [NonSerialized]  // Indica que este campo no debe ser serializado
        private string internalData;

        [ComVisible(true)]  // Indica que la clase es visible para COM
        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Category: {Category}");
            Console.WriteLine($"Type: {Type}");
            Console.WriteLine($"Nit: {Nit}");
            Console.WriteLine($"EmailAddress: {EmailAddress}");
            Console.WriteLine($"Address: {Address}");
            Console.WriteLine($"PhoneNumber: {PhoneNumber}");
            Console.WriteLine($"City: {City}");
            Console.WriteLine($"Region: {Region}");

            // Reflexión para mostrar atributos
            Console.WriteLine("\nAtributos de propiedades:");
            foreach (PropertyInfo prop in typeof(TiendaRopa).GetProperties())
            {
                Console.WriteLine($"\nPropiedad: {prop.Name}");

                var defaultValueAttr = prop.GetCustomAttribute<DefaultValueAttribute>();
                if (defaultValueAttr != null)
                {
                    Console.WriteLine($"Valor por defecto: {defaultValueAttr.Value}");
                }

                var categoryAttr = prop.GetCustomAttribute<CategoryAttribute>();
                if (categoryAttr != null)
                {
                    Console.WriteLine($"Categoría: {categoryAttr.Category}");
                }

                var browsableAttr = prop.GetCustomAttribute<BrowsableAttribute>();
                if (browsableAttr != null)
                {
                    Console.WriteLine($"Browsable: {browsableAttr.Browsable}");
                }

                var obsoleteAttr = prop.GetCustomAttribute<ObsoleteAttribute>();
                if (obsoleteAttr != null)
                {
                    Console.WriteLine($"Obsoleto: {obsoleteAttr.Message}");
                }
            }

            // Reflexión para mostrar atributos de la clase
            Console.WriteLine("\nAtributos de la clase:");
            var classAttr = typeof(TiendaRopa).GetCustomAttributes(false);
            foreach (var attr in classAttr)
            {
                if (attr is SerializableAttribute)
                {
                    Console.WriteLine("La clase es serializable.");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Crear una instancia de TiendaRopa con datos de ejemplo
            TiendaRopa tienda = new TiendaRopa
            {
                Id = 1,
                Name = "Tienda de Ropa XYZ",
                Description = "Venta de ropa para todas las edades y clases de personas",
                Category = "Ropa infantil, deportiva, interior",
                Type = "Minorista",
                Nit = 123456789,
                EmailAddress = "contacto@tiendaderopa.xyz",
                Address = "123 Calle Principal",
                PhoneNumber = "555-1234",
                City = "Bogotá",
                Region = "Cundinamarca"
            };

            // Llamar al método DisplayInfo para mostrar la información de la tienda
            tienda.DisplayInfo();
        }
    }
}
