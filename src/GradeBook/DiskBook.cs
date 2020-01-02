using System.IO;

namespace GradeBook
{
    public class DiskBook : Book
    {
        private string v;

        public DiskBook(string name): base(name)
        {
            this.v = name;
        }

        public override event GradeAddedDelegate GradeAdded;
        
        public override void AddGrade(double grade){
            using(var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new System.EventArgs());
                }
            }
            
        }
        
    }
}