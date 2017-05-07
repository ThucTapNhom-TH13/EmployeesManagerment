using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class NhanVien
    {
        private int mId;
        private String mName;
        private DateTime mDob;
        private bool mIsMale;
        private String mPhoneNumber;
        private String mAddress;
        private decimal mSalary;
        private int mSupervisorId;
        private int mDepartmentId;

        public int MId
        {
            get
            {
                return mId;
            }

            set
            {
                mId = value;
            }
        }

        public string MName
        {
            get
            {
                return mName;
            }

            set
            {
                mName = value;
            }
        }

        public DateTime MDob
        {
            get
            {
                return mDob;
            }

            set
            {
                mDob = value;
            }
        }

        public bool MIsMale
        {
            get
            {
                return mIsMale;
            }

            set
            {
                mIsMale = value;
            }
        }

        public string MPhoneNumber
        {
            get
            {
                return mPhoneNumber;
            }

            set
            {
                mPhoneNumber = value;
            }
        }

        public decimal MSalary
        {
            get
            {
                return mSalary;
            }

            set
            {
                mSalary = value;
            }
        }

        public int MSupervisorId
        {
            get
            {
                return mSupervisorId;
            }

            set
            {
                mSupervisorId = value;
            }
        }

        public int MDepartmentId
        {
            get
            {
                return mDepartmentId;
            }

            set
            {
                mDepartmentId = value;
            }
        }

        public string MAddress
        {
            get
            {
                return mAddress;
            }

            set
            {
                mAddress = value;
            }
        }

        public NhanVien(int id, String name, DateTime dob, bool isMale, String phoneNumber,
            String address, decimal salary, int supervisorId, int departmentId)
        {
            MId = id;
            MName = name;
            MDob = dob;
            MIsMale = isMale;
            MPhoneNumber = phoneNumber;
            mAddress = address;
            MSalary = salary;
            MSupervisorId =supervisorId;
            MDepartmentId = departmentId;
        }

    }
}
