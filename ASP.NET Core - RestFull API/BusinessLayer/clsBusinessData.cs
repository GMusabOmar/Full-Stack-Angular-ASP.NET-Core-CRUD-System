using DataLayer;

namespace BusinessLayer
{
    public class clsBusinessData
    {
        public enum enType { Add, Update}
        private enType _Type = enType.Add;
        public int id {  get; set; }
        public string? name { get; set; }
        public int age { get; set; }
        public string? address { get; set; }
        public clsStudentsDOT StudentDOT
        {
            get
            {
                return new clsStudentsDOT(this.id, this.name, this.age, this.address);
            }
        }
        public clsBusinessData(clsStudentsDOT DOT, enType Type = enType.Add)
        {
            this.id = DOT.id;
            this.name = DOT.name;
            this.age = DOT.age;
            this.address = DOT.address;
            this._Type = Type;
        }
        public static List<clsStudentsDOT> GetAllStudents()
        {
            return clsDataLayer.GetAllStudents();
        }
        public static clsBusinessData? GetStudentByID(int id)
        {
            var getStudentByID = clsDataLayer.GetStudentByID(id);
            if (getStudentByID != null)
                return new clsBusinessData(getStudentByID, enType.Update);
            return null;
        }
        private bool _AddNewStudent()
        {
            this.id = clsDataLayer.AddNewStudent(StudentDOT);
            return this.id > 0;
        }
        private bool _UpdateStudent()
        {
            return clsDataLayer.UpdateStudent(StudentDOT);
        }
        public bool Save()
        {
            switch(_Type)
            {
                case enType.Add:
                    if (_AddNewStudent())
                    {
                        this._Type = enType.Update;
                        return true;
                    }
                    else
                        return false;
                case enType.Update:
                    return _UpdateStudent();
            }
            return false;
        }
        public bool DeleteStudent(int id)
        {
            return clsDataLayer.DeleteStudent(id);
        }
    }
}
