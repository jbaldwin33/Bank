﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.MyBank.Models
{
  public static class Enums
  {
    public enum AccountTypeEnum
    {
      Checking,
      Saving
    }

    public enum UserEnum
    {
      Administrator = 0,
      User
    }

    public enum CommandType
    {
      Add,
      Edit,
      Delete
    }
  }
}
