using Cognify.Models;
using Cognify.Models.Factory;
using Cognify.Models.Singleton;
using Cognify.Models.Builder;
using Microsoft.AspNetCore.Mvc;

namespace Cognify.Controllers
{
    public class MemoryController : Controller
    {
        private static List<Simulation> _simulations = new List<Simulation>();

        // GET: Memory
        public IActionResult Index()
        {
            return View(_simulations); // Mostrar las simulaciones almacenadas
        }

        // GET: Memory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Memory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string description, string intensity, string duration, string crimeType, string sentencingOption)
        {
            // Si se elige la sentencia tradicional, no se crea simulación ni recuerdo
            if (sentencingOption == "Traditional")
            {
                // Registrar o hacer alguna acción relacionada con la sentencia tradicional
                TempData["Message"] = "Se ha elegido cumplir una sentencia tradicional. No se ha generado ningún recuerdo ni simulación."; // Usar TempData
                return RedirectToAction(nameof(Index)); // Redirigir a la vista principal
            }

            // Intentar crear el recuerdo según el tipo de crimen y manejar posibles errores
            try
            {
                var memory = GenerateMemoryForCrimeType(crimeType, intensity, duration);

                // Crear la simulación y agregar el recuerdo
                var simulation = new Simulation(crimeType);
                simulation.AddMemory(memory);

                // Ejecutar la simulación
                simulation.RunSimulation();

                // Agregar la simulación a la lista
                _simulations.Add(simulation);

                // Agregar mensaje de éxito a TempData
                TempData["SuccessMessage"] = "La simulación ha sido creada exitosamente con el recuerdo generado.";

                // Redirigir a la vista principal con las simulaciones actualizadas
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException ex)
            {
                // En caso de que se lance una excepción (por ejemplo, si la intensidad es inválida)
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // Método para generar el recuerdo según el tipo de crimen
        private Memory GenerateMemoryForCrimeType(string crimeType, string intensity, string duration)
        {
            string description = string.Empty;

            // Asignar una descripción dependiendo del tipo de crimen
            switch (crimeType)
            {
                case "Violent":
                    description = GenerateViolentCrimeMemory(intensity);
                    break;

                case "Theft":
                    description = GenerateTheftCrimeMemory(intensity);
                    break;

                case "Financial":
                    description = GenerateFinancialCrimeMemory(intensity);
                    break;

                case "Hate":
                    description = GenerateHateCrimeMemory(intensity);
                    break;

                default:
                    throw new ArgumentException("Tipo de crimen no válido.");
            }

            // Usar el builder para crear el recuerdo
            var memoryBuilder = new MemoryBuilder();
            var memory = memoryBuilder.SetDescription(description)
                                      .SetIntensity(intensity)
                                      .SetDuration(duration)
                                      .Build();

            return memory;
        }

        // Métodos específicos para cada tipo de crimen y su descripción

        private string GenerateViolentCrimeMemory(string intensity)
        {
            return intensity switch
            {
                "Low" => "Recuerdo de crimen violento con baja intensidad: un encuentro breve y violento.",
                "Medium" => "Recuerdo de crimen violento con intensidad media: una situación violenta que dura más tiempo.",
                "High" => "Recuerdo de crimen violento con alta intensidad: el sufrimiento de la víctima y la violencia extrema.",
                _ => throw new ArgumentException("Intensidad no válida")
            };
        }

        private string GenerateTheftCrimeMemory(string intensity)
        {
            return intensity switch
            {
                "Low" => "Recuerdo de robo con baja intensidad: un robo menor sin consecuencias graves.",
                "Medium" => "Recuerdo de robo con intensidad media: el robo y su impacto en la víctima.",
                "High" => "Recuerdo de robo con alta intensidad: las consecuencias económicas devastadoras del robo.",
                _ => throw new ArgumentException("Intensidad no válida")
            };
        }

        private string GenerateFinancialCrimeMemory(string intensity)
        {
            return intensity switch
            {
                "Low" => "Recuerdo de crimen financiero con baja intensidad: la falta de conciencia de las consecuencias.",
                "Medium" => "Recuerdo de crimen financiero con intensidad media: el impacto a largo plazo de sus actos.",
                "High" => "Recuerdo de crimen financiero con alta intensidad: la devastación económica causada por sus actos.",
                _ => throw new ArgumentException("Intensidad no válida")
            };
        }

        private string GenerateHateCrimeMemory(string intensity)
        {
            return intensity switch
            {
                "Low" => "Recuerdo de crimen de odio con baja intensidad: un acto de odio menor.",
                "Medium" => "Recuerdo de crimen de odio con intensidad media: la discriminación y su impacto social.",
                "High" => "Recuerdo de crimen de odio con alta intensidad: el sufrimiento de las víctimas y las repercusiones sociales.",
                _ => throw new ArgumentException("Intensidad no válida")
            };
        }
    }
}
