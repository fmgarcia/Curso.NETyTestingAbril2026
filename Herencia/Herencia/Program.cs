namespace Herencia
{
    class Program
    {
        static void Main(string[] args)
        {

            Animal animal1 = new Animal();
            animal1.Nombre = "Generic Animal";
            animal1.Edad = 5;


            Perro perro = new Perro
            {
                Nombre = "Rex",       // Heredado de Animal
                Edad = 3,             // Heredado de Animal
                Raza = "Pastor alemán" // Propio de Perro
            };

            perro.Comer();   // Heredado de Animal: "Rex está comiendo."
            perro.Ladrar();  // Propio de Perro: "Rex dice: ¡Guau!"

            Gato gato = new Gato { Nombre = "Luna", Edad = 2, EsDeInterior = true };
            gato.Comer();    // Heredado de Animal
            gato.Maullar();  // Propio de Gato 
        }
    }

}
