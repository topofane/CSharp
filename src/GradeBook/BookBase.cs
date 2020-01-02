namespace GradeBook
{
    public abstract class BookBase : NamedObject, IBook
    {
        public BookBase(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }
}