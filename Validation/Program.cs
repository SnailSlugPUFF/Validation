﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Validation
{
    public partial class Program
    {
        public static void Main()
        {
            CreateStudent("Dmitriy", 3);
            CreateStudent("Alexey", 6);
            CreateStudent("Igor", 1);
            Console.ReadKey();
        }

        static void CreateStudent(string name, int studyyear)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type studentType = assembly.GetType("Validation.Student");

            object[] args = { name, studyyear };
            object student1 = Activator.CreateInstance(studentType, args);

            PropertyInfo nameProp = studentType.GetProperty("Name");
            PropertyInfo studyyearProp = studentType.GetProperty("StudyYear");

            var context = new ValidationContext(student1);
            var result = new List<ValidationResult>();

            Console.WriteLine($"Name: {studentType.Name}");             
            Console.WriteLine($"Full Name: {studentType.FullName}");     
            Console.WriteLine($"Namespace: {studentType.Namespace}");    
            Console.WriteLine($"Is struct: {studentType.IsValueType}");
            Console.WriteLine($"Is class: {studentType.IsClass}");       

            if (!Validator.TryValidateObject(student1, context, result, true))
            {
                Console.WriteLine("Не удалось создать объект Student");
                foreach (var error in result)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                Console.WriteLine();
            }
            else
                Console.WriteLine($"Объект Student успешно создан. Student name: {nameProp.GetValue(student1)} , Student study year: {studyyearProp.GetValue(student1)}\n");
        }
    }
}