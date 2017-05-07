﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entity;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BUS
{
    public class tblNhanVien_BUS
    {
        public static String getEmplName(int manv)
        {
            return tblNhanVien_DAL.getEmplNameById(manv);
        }

        public static DataView getAll()
        {
            return tblNhanVien_DAL.getAll();
        }

        public static void editEmployee(NhanVien employee)
        {
            tblNhanVien_DAL.editEmployee(employee);
        }

        public static void addEmployee(NhanVien employee)
        {
            tblNhanVien_DAL.addEmployee(employee);
        }

        public static void loadDepartmentCombobox(ComboBox comboBox)
        {
            tblNhanVien_DAL.loadDepartmentCombobox(comboBox);
        }

        public static void loadSupervisorComboBox(ComboBox comboBox, int employeeId)
        {
            tblNhanVien_DAL.loadSupervisorComboBox(comboBox, employeeId);
        }

        public static DataView getProjects(int employeeId)
        {
            return tblNhanVien_DAL.getProjects(employeeId);
        }

        public static void deleteEmployee(int id)
        {
            tblNhanVien_DAL.deleteEmployee(id);
        }
    }
}
