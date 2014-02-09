
namespace _03.Exercise
{
    public class Folder
    {
        public string name = string.Empty;
        public File[] files = null;
        public Folder[] childFolders = null;

        public Folder(string name)
        {
            this.name = name;
        }
    }
}
