using System.Collections.Generic;
using System.Linq;
using Assignment3.Repositories;
using Assignment3.Models;

namespace Assignment3.App
{
  public class HealthSystemApp
  {
    private readonly Repository<Patient> _patientRepo = new Repository<Patient>();
    private readonly Repository<Prescription> _prescriptionRepo = new Repository<Prescription>();
    private readonly Dictionary<int, List<Prescription>> _prescriptionMap = new Dictionary<int, List<Prescription>>();

    public void SeedData()
    {
      // Add Patients
      _patientRepo.Add(new Patient(1, "Kwame Akoto", 22, "Male"));
      _patientRepo.Add(new Patient(2, "Ama Serwaa", 30, "Female"));
      _patientRepo.Add(new Patient(3, "Agya Mensah", 45, "Male"));

      // Add Prescriptions
      _prescriptionRepo.Add(new Prescription(1, 1, "Amoxicillin", DateTime.Now.AddDays(-5)));
      _prescriptionRepo.Add(new Prescription(2, 1, "Ibuprofen", DateTime.Now.AddDays(-1)));
      _prescriptionRepo.Add(new Prescription(3, 2, "Paracetamol", DateTime.Now.AddDays(-3)));
      _prescriptionRepo.Add(new Prescription(4, 3, "Vitamin C", DateTime.Now.AddDays(-2)));
    }

    public void BuildPrescriptionMap()
    {
      foreach (var prescription in _prescriptionRepo.GetAll())
      {
        if (!_prescriptionMap.ContainsKey(prescription.PatientId))
        {
          _prescriptionMap[prescription.PatientId] = new List<Prescription>();
        }
        _prescriptionMap[prescription.PatientId].Add(prescription);
      }
    }

    public void PrintAllPatients()
    {
      Console.WriteLine("All Patients:");
      foreach (var patient in _patientRepo.GetAll())
      {
        Console.WriteLine(patient);
      }
    }

    public void PrintPrescriptionsForPatient(int patientId)
    {
      if (_prescriptionMap.ContainsKey(patientId))
      {
        Console.WriteLine($"Prescriptions for patient ID {patientId}:");
        foreach (var prescription in _prescriptionMap[patientId])
        {
          Console.WriteLine(prescription);
        }
      }
      else
      {
        Console.WriteLine($"No prescriptions found for Patient Id {patientId}");
      }
    }

    public void Run()
    {
      SeedData();
      BuildPrescriptionMap();

      PrintAllPatients();

      Console.WriteLine("\n--- Prescriptions for a Selected Patient ---");
      PrintPrescriptionsForPatient(1);
    }
  }
}