using Assignment3.Repositories;
using Assignment3.Models;

// namespace Assignment3.App
// {
//   public class HealthSystemApp
//   {
//     private readonly Repository<Patient> _patientRepo = new Repository<Patient>();
//     private readonly Repository<Prescription> _prescriptionRepo = new Repository<Prescription>();
//     private readonly Dictionary<int, List<Prescription>> _prescriptionMap = new Dictionary<int, List<Prescription>>();

//     public void SeedData()
//     {
//       // Add Patients
//       _patientRepo.Add(new Patient(1, "Kwame Akoto", 22, "Male"));
//       _patientRepo.Add(new Patient(2, "Ama Serwaa", 30, "Female"));
//       _patientRepo.Add(new Patient(3, "Agya Mensah", 45, "Male"));

//       // Add Prescriptions
//       _prescriptionRepo.Add(new Prescription(1, 1, "Amoxicillin", DateTime.Now.AddDays(-5)));
//       _prescriptionRepo.Add(new Prescription(2, 1, "Ibuprofen", DateTime.Now.AddDays(-1)));
//       _prescriptionRepo.Add(new Prescription(3, 2, "Paracetamol", DateTime.Now.AddDays(-3)));
//       _prescriptionRepo.Add(new Prescription(4, 3, "Vitamin C", DateTime.Now.AddDays(-2)));
//     }

//     public void BuildPrescriptionMap()
//     {
//       foreach (var prescription in _prescriptionRepo.GetAll())
//       {
//         if (!_prescriptionMap.ContainsKey(prescription.PatientId))
//         {
//           _prescriptionMap[prescription.PatientId] = new List<Prescription>();
//         }
//         _prescriptionMap[prescription.PatientId].Add(prescription);
//       }
//     }

//     public void PrintAllPatients()
//     {
//       Console.WriteLine("All Patients:");
//       foreach (var patient in _patientRepo.GetAll())
//       {
//         Console.WriteLine(patient);
//       }
//     }

//     public void PrintPrescriptionsForPatient(int patientId)
//     {
//       if (_prescriptionMap.ContainsKey(patientId))
//       {
//         Console.WriteLine($"Prescriptions for patient ID {patientId}:");
//         foreach (var prescription in _prescriptionMap[patientId])
//         {
//           Console.WriteLine(prescription);
//         }
//       }
//       else
//       {
//         Console.WriteLine($"No prescriptions found for Patient Id {patientId}");
//       }
//     }

//     public void Run()
//     {
//       SeedData();
//       BuildPrescriptionMap();

//       PrintAllPatients();

//       Console.WriteLine("\n--- Prescriptions for a Selected Patient ---");
//       PrintPrescriptionsForPatient(1);
//     }
//   }
// }

namespace Assignment3.App
{
  public class HealthSystemApp
  {
    private readonly Repository<Patient> _patientRepo = new();
    private readonly Repository<Prescription> _prescriptionRepo = new();

    public void SeedData()
    {
      _patientRepo.Add(new Patient(1, "John Doe", 30, "Male"));
      _patientRepo.Add(new Patient(2, "Jane Smith", 25, "Female"));
      _prescriptionRepo.Add(new Prescription(1, 1, "Amoxicillin", DateTime.Now.AddDays(-10)));
      _prescriptionRepo.Add(new Prescription(2, 2, "Ibuprofen", DateTime.Now.AddDays(-5)));
    }

    public void AddPatient()
    {
      Console.Write("Enter Patient ID: ");
      string? idInput = Console.ReadLine();
      if (string.IsNullOrWhiteSpace(idInput) || !int.TryParse(idInput, out int id))
      {
        Console.WriteLine("❌ Invalid Patient ID!");
        return;
      }

      Console.Write("Enter Name: ");
      string? name = Console.ReadLine();
      if (string.IsNullOrWhiteSpace(name))
      {
        Console.WriteLine("❌ Name cannot be empty!");
        return;
      }

      Console.Write("Enter Age: ");
      string? ageInput = Console.ReadLine();
      if (!int.TryParse(ageInput, out int age))
      {
        Console.WriteLine("❌ Invalid Age!");
        return;
      }

      Console.Write("Enter Gender: ");
      string? gender = Console.ReadLine();
      if (string.IsNullOrWhiteSpace(gender))
      {
        Console.WriteLine("❌ Gender cannot be empty!");
        return;
      }

      var patient = new Patient(id, name, age, gender);
      _patientRepo.Add(patient);
      Console.WriteLine("✅ Patient added successfully!");
    }

    public void AddPrescription()
    {
      Console.Write("Enter Prescription ID: ");
      string? prescIdInput = Console.ReadLine();
      if (string.IsNullOrWhiteSpace(prescIdInput) || !int.TryParse(prescIdInput, out int id))
      {
        Console.WriteLine("❌ Invalid Prescription ID!");
        return;
      }

      Console.Write("Enter Patient ID: ");
      string? patientIdInput = Console.ReadLine();
      if (string.IsNullOrWhiteSpace(patientIdInput) || !int.TryParse(patientIdInput, out int patientId))
      {
        Console.WriteLine("❌ Invalid Patient ID!");
        return;
      }

      // Validation: Patient must exist
      if (_patientRepo.GetById(patientId) == null)
      {
        Console.WriteLine("❌ Patient does not exist!");
        return;
      }

      Console.Write("Enter Medication Name: ");
      string? med = Console.ReadLine();
      if (string.IsNullOrWhiteSpace(med))
      {
        Console.WriteLine("❌ Medication name cannot be empty!");
        return;
      }

      var prescription = new Prescription(id, patientId, med, DateTime.Now);
      _prescriptionRepo.Add(prescription);
      Console.WriteLine("✅ Prescription added successfully!");
    }

    public void PrintPrescriptionsForPatient(int patientId)
    {
      var patient = _patientRepo.GetById(patientId);
      if (patient == null)
      {
        Console.WriteLine("❌ Patient not found!");
        return;
      }

      Console.WriteLine($"\nPrescriptions for {patient.Name}:");
      foreach (var p in _prescriptionRepo.GetAll().Where(p => p.PatientId == patientId))
      {
        Console.WriteLine($"- {p.MedicationName} (Issued: {p.DateIssued})");
      }
    }

    public void PrintAllPatients()
    {
      Console.WriteLine("\nAll Patients:");
      foreach (var patient in _patientRepo.GetAll())
      {
        // Console.WriteLine($"- {patient.Name} (ID: {patient.Id})");
        Console.WriteLine(patient);
      }
    }

    public void Run()
    {
      SeedData();
      while (true)
      {
        Console.WriteLine("\n--- Health System Menu ---");
        Console.WriteLine("1. Add Patient");
        Console.WriteLine("2. Add Prescription");
        Console.WriteLine("3. View Patient Prescriptions");
        Console.WriteLine("4. View All Patients");
        Console.WriteLine("0. Exit");
        Console.Write("Select an option: ");

        var input = Console.ReadLine();
        switch (input)
        {
          case "1": AddPatient(); break;
          case "2": AddPrescription(); break;
          case "3":
            Console.Write("Enter Patient ID: ");
            var inputId = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(inputId) || !int.TryParse(inputId, out int id))
            {
              Console.WriteLine("❌ Invalid Patient ID");
              break;
            }
            PrintPrescriptionsForPatient(id);
            break;
          case "4": PrintAllPatients(); break;
          case "0": return;
          default: Console.WriteLine("❌ Invalid option"); break;
        }
      }
    }
  }
}
