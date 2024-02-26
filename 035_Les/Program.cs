using DB;
using DB.Repos;
using Newtonsoft.Json;

namespace ConsoleApp
{
	class Program
	{
		static async Task Main(string[] args)
		{
			Database db = new();
			RobotRepository robotRepository = new(db);

			while (true)
			{
				Console.WriteLine("1. Add Robot");
				Console.WriteLine("2. Update Robot");
				Console.WriteLine("3. Delete Robot");
				Console.WriteLine("4. Get Robot by ID");
				Console.WriteLine("5. Get all Robots");
				Console.WriteLine("6. Exit");
				Console.WriteLine("Choose an option: ");
				var option = Console.ReadLine();

				switch (option)
				{
					case "1": // Add Robot
						var robotToAdd = new Robot
						{
							Id = Guid.NewGuid(),
							Arms = new List<Arm>(),
							Legs = new List<Leg>(),
							Torso = new Torso(),
							Head = HeadType.Spherical
						};

						// Add arms
						Console.WriteLine("How many arms? ");
						int armsCount = int.Parse(Console.ReadLine());
						for (int i = 0; i < armsCount; i++)
						{
							robotToAdd.Arms.Add(new Arm
							{
								Material = GetMaterial(),
								NumberOfJoints = GetIntValue("Enter number of joints for arm: "),
								NumberOfFingers = GetIntValue("Enter number of fingers for arm: ")
							});
						}

						// Add legs
						Console.WriteLine("How many legs? ");
						int legsCount = int.Parse(Console.ReadLine());
						for (int i = 0; i < legsCount; i++)
						{
							robotToAdd.Legs.Add(new Leg
							{
								Material = GetMaterial(),
								NumberOfJoints = GetIntValue("Enter number of joints for leg: "),
								SizeOfFoot = GetFloatValue("Enter size of foot for leg: ")
							});
						}

						// Add torso
						robotToAdd.Torso = new Torso
						{
							Material = GetMaterial(),
							ChestMeasurements = GetChestMeasurements(),
							WaistMeasurements = GetWaistMeasurements()
						};

						// Choose head type
						robotToAdd.Head = GetHeadType();

						await robotRepository.CreateRobot(robotToAdd);
						Console.WriteLine("Robot added successfully.");
						break;

					case "2": // Update Robot
						Console.WriteLine("Enter robot ID to update: ");
						var updateId = Guid.Parse(Console.ReadLine());
						var robotToUpdate = await robotRepository.GetRobotById(updateId);
						// Assume we're just updating the head type for simplicity
						robotToUpdate.Head = GetHeadType();
						await robotRepository.UpdateRobot(robotToUpdate);
						Console.WriteLine("Robot updated successfully.");
						break;

					case "3": // Delete Robot
						Console.WriteLine("Enter robot ID to delete: ");
						var deleteId = Guid.Parse(Console.ReadLine());
						await robotRepository.DeleteRobot(deleteId);
						Console.WriteLine("Robot deleted successfully.");
						break;

					case "4": // Get Robot by ID
						Console.WriteLine("Enter robot ID: ");
						var getById = Guid.Parse(Console.ReadLine());
						var robot = await robotRepository.GetRobotById(getById);
						Console.WriteLine(JsonConvert.SerializeObject(robot, Formatting.Indented));
						
						break;

					case "5": // Get all Robots
						var allRobots = await robotRepository.GetAllRobots();
						foreach (var r in allRobots)
						{
							Console.WriteLine($"Robot ID: {r.Id}");
						}
						break;

					case "6": // Exit
						return;

					default:
						Console.WriteLine("Invalid option. Please try again.");
						break;
				}
			}
		}

		static Material GetMaterial()
		{
			Console.WriteLine("Enter material name: ");
			var name = Console.ReadLine();
			Console.WriteLine("Enter material description: ");
			var description = Console.ReadLine();
			Console.WriteLine("Enter material density: ");
			var density = float.Parse(Console.ReadLine());
			return new Material { Name = name, Description = description, Density = density };
		}

		static int GetIntValue(string message)
		{
			Console.WriteLine(message);
			return int.Parse(Console.ReadLine());
		}

		static float GetFloatValue(string message)
		{
			Console.WriteLine(message);
			return float.Parse(Console.ReadLine());
		}

		static ChestMeasurements GetChestMeasurements()
		{
			Console.WriteLine("Enter chest height: ");
			var height = float.Parse(Console.ReadLine());
			Console.WriteLine("Enter chest width: ");
			var width = float.Parse(Console.ReadLine());
			Console.WriteLine("Enter chest depth: ");
			var depth = float.Parse(Console.ReadLine());
			return new ChestMeasurements { Height = height, Width = width, Depth = depth };
		}

		static WaistMeasurements GetWaistMeasurements()
		{
			Console.WriteLine("Enter waist height: ");
			var height = float.Parse(Console.ReadLine());
			Console.WriteLine("Enter waist width: ");
			var width = float.Parse(Console.ReadLine());
			return new WaistMeasurements { Height = height, Width = width };
		}

		static HeadType GetHeadType()
		{
			Console.WriteLine("Choose head type (1- Spherical, 2- Cubical, 3- Cylindrical): ");
			var choice = int.Parse(Console.ReadLine());
			return choice switch
			{
				1 => HeadType.Spherical,
				2 => HeadType.Cubical,
				3 => HeadType.Cylindrical,
				_ => HeadType.Spherical
			};
		}
	}
}