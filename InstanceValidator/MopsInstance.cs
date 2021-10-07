namespace InstanceValidator
{
    public class MopsInstance
    {
        private string _foldername;
        private string _fullpathconfigfile;
        private int _instanceid;

        public MopsInstance(string aFoldername, string aFullpathconfigfile, int aInstanceid)
        {
            _foldername = aFoldername;
            _fullpathconfigfile = aFullpathconfigfile;
            _instanceid = aInstanceid;
        }

        public MopsInstance(string aFoldername)
        {
            _foldername = aFoldername;

        }

        public MopsInstance(int aInstanceid)
        {
            _instanceid = aInstanceid;
        }

        public string FolderName
        {
            get
            {
                return _foldername;
            }
            set
            {
                _foldername = value;
            }
        }

        public string FullPathConfigFile
        {
            get
            {
                return _fullpathconfigfile;
            }
            set
            {
                _fullpathconfigfile = value;
            }
        }
        public int InstanceId
        {
            get
            {
                return _instanceid;
            }
            set
            {
                int _instanceid = value;
            }
        }
    }
}
