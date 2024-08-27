using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiRestFull_Employees.Models;

[Table("Employees")]
public class EmployeeRequest
{
    public string HireDate { get; set; }
}
