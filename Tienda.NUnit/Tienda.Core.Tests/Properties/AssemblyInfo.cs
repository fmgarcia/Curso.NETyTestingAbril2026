using NUnit.Framework;

[assembly: Parallelizable(ParallelScope.Fixtures)] // Permite la ejecución paralela de los conjuntos de pruebas
[assembly: LevelOfParallelism(4)] // Establece el número máximo de hilos para la ejecución paralela (ajusta según tus necesidades)
