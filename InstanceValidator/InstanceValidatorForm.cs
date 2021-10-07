namespace InstanceValidator
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Windows.Forms;
    using System.Xml;

    public partial class InstanceValidatorForm : Form
    {
        public InstanceValidatorForm()
        {
            InitializeComponent();
        }

        internal const string basePath = "D:\\Mc4LEA\\MOPS\\";
        internal List<MopsInstance> mopsInstanceInfo = new List<MopsInstance>();
        internal List<string> mopsDirectory = new List<string>();
        internal List<string> mopsConfg = new List<string>();
        internal List<string> dbInstances = new List<string>();
        private void printTextLocal()
        {
            folderCount();
            cleanDirectories();
            textLocalInstances.Text = "Local machine IP: " + GetLocalIPAddress() + "\r\n";
            foreach (string item in mopsDirectory)
            {
                printLocal(item);
            }
        }
        private void printLocal(string item)
        {
            string fullConfigPath = getConfigPath(item);
            MopsInstance mops = new MopsInstance(item, fullConfigPath, getInstance(fullConfigPath));
            mopsInstanceInfo.Add(mops);
            textLocalInstances.Text += "\r\n";
            textLocalInstances.Text += mops.FolderName;
            textLocalInstances.Text += ":" + mops.InstanceId.ToString();
        }
        private void printTextDb()
        {
            string connectionIp = getMachineDb();
            if (checkValidIpAdress(connectionIp))
            {
                textDbInstances.Text = "DB IP: " + connectionIp + "\r\n" + "\r\n";
                dbInstances.Clear();
                getDbInstances(connectionIp);
                dbInstances.Sort();
                foreach (string item in dbInstances)
                {
                    textDbInstances.Text += item;
                }
            }
            else
            {
                MessageBox.Show("Coundnt find DB ip address in features.xml file found: " + connectionIp);
            }
        }
        private bool checkValidIpAdress(string connectionIp)
        {
            IPAddress address;
            if (IPAddress.TryParse(connectionIp, out address))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void cleanDirectories()
        {
            for (int i = 0; i < mopsDirectory.Count(); i++)
            {
                string item = mopsDirectory[i];
                if (item.Contains("Service"))
                {
                    item = item.Substring(0, item.IndexOf("Service") + 7);
                }
                if (item.Contains("Mediator"))
                {
                    item = item.Substring(0, item.IndexOf("Mediator") + 8);
                }
                mopsDirectory[i] = item;

            }
            mopsDirectory = mopsDirectory.Distinct().ToList();
            foreach(string i in mopsDirectory)
            {
                comboBox1.Items.Add(i);
            }
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        private int getInstance(string fullConfigPath)
        {
            int instanceID = 0;
            string cleanValue;
            int placeOfInstanceId = 40;
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(fullConfigPath);
                XmlNodeList elemList = doc.GetElementsByTagName("configuration");
                placeOfInstanceId = placeOfInstanceId + elemList[0].InnerXml.IndexOf("InstanceId");
                cleanValue = elemList[0].InnerXml.Substring(placeOfInstanceId);
                cleanValue = cleanValue.Substring(0, cleanValue.IndexOf("</"));
                instanceID = Int32.Parse(cleanValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Coundnt find : " + fullConfigPath + "\r\n" + ex.Message);
            }
            return instanceID;
        }
        private void setInstance(string fullConfigPath, string newInstanceId, string oldInstanceId)
        {
            try
            {
                string featuresXml = File.ReadAllText(fullConfigPath);
                featuresXml = featuresXml.Replace(oldInstanceId, newInstanceId);
                File.WriteAllText(fullConfigPath, featuresXml);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Coundnt change : " + fullConfigPath + "\r\n" + ex.Message);
            }
        }
        private string getConfigPath(string folderName)
        {
            string configFile = folderName;
            string folderPath;
            string fullConfigFliePath;
            folderPath = basePath + folderName;
            if (!folderName.Contains("Client"))
            {
                configFile = folderName.Substring(5);
            }
            configFile = configFile + ".exe.config";
            configFile = String.Concat(configFile.Where(c => !Char.IsWhiteSpace(c)));
            fullConfigFliePath = folderPath + "\\" + configFile;
            mopsConfg.Add(fullConfigFliePath);
            return fullConfigFliePath;
        }
        private int folderCount()
        {
            DirectoryInfo dir = new DirectoryInfo(basePath);
            DirectoryInfo[] dirArr = dir.GetDirectories();
            int count = dir.GetDirectories().Length;
            for (int i = 0; i < dirArr.Length; i++)
            {
                if (!dirArr[i].Name.Contains("Mediator"))
                {
                    if (!dirArr[i].Name.Contains("Service"))
                    {
                        count--;
                    }
                    else
                    {
                        if (dirArr[i].Name.Contains("Local") || dirArr[i].Name.Contains("Copy") || dirArr[i].Name.Contains("-") || dirArr[i].Name.Contains("_") || dirArr[i].Name.Contains("Wcf") || dirArr[i].Name.Contains("Client") || dirArr[i].Name.Contains("Health ")) { }
                        else {
                            mopsDirectory.Add(dirArr[i].Name);                 
                        }
                    }
                }
                else
                {
                    if (dirArr[i].Name.Contains("Local") || dirArr[i].Name.Contains("Copy") || dirArr[i].Name.Contains("-") || dirArr[i].Name.Contains("_") || dirArr[i].Name.Contains("Wcf") || dirArr[i].Name.Contains("Client") || dirArr[i].Name.Contains("Health ")) { }
                    else { 
                        mopsDirectory.Add(dirArr[i].Name);
                    }
                }
            }
            return count;
        }
        private string getMachineDb()
        {
            string featurePath = "D:\\Mc4LEA\\MOPS\\MopsLocalConfiguration\\Features.xml";
            string connectionIp = "";
            int placeOfMopsAdminConnectionString = 60;

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(featurePath);
                XmlNodeList elemList = doc.GetElementsByTagName("Configuration");
                placeOfMopsAdminConnectionString = placeOfMopsAdminConnectionString + elemList[0].InnerXml.IndexOf("MopsAdminConnectionString");
                connectionIp = elemList[0].InnerXml.Substring(placeOfMopsAdminConnectionString);
                connectionIp = connectionIp.Substring(0, connectionIp.IndexOf(";"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Coudnt find features file under :" + featurePath + "\r\n" + ex.Message);
                return connectionIp;
            }
            return connectionIp;
        }
        private void getDbInstances(string connectionIp)
        {
            string queryString = "SELECT instanceId , DeviceName FROM dev.DeviceInstanceIds INNER JOIN dev.devices ON dev.DeviceInstanceIds.DeviceId = dev.devices.DeviceId";
            string connectionString = "Server=" + connectionIp + "; Database=MappingDb;User Id=sa;Password=Password1;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    string dbLine = ReadSingleRow((IDataRecord)reader);
                    if (!(dbLine.Contains("Client")) && (!dbLine.Contains("Record")))
                    {
                        int numOfWords = CountWords(dbLine);
                        if (numOfWords >= 3)
                        {
                            dbInstances.Add(ReadSingleRow((IDataRecord)reader) + "\r\n");

                        }
                    }
                }
                // Call Close when done reading.
                reader.Close();
            }
        }
        private string ReadSingleRow(IDataRecord record)
        {
            string firsWord;
            string myString = String.Format("{0}", record[1]);
            try
            {
                myString = myString.Substring(0, myString.LastIndexOf(" "));
                firsWord = myString.Substring(0, myString.IndexOf(" "));
                if (firsWord != "Mops" && firsWord != "MOPS")
                {
                    myString = "Mops " + myString;
                }
            }
            catch (Exception)
            {
            }
            return (String.Format("{0}, {1}", myString, record[0]));
        }
        public static int CountWords(string test)
        {
            int count = 0;
            bool wasInWord = false;
            bool inWord = false;

            for (int i = 0; i < test.Length; i++)
            {
                if (inWord)
                {
                    wasInWord = true;
                }

                if (Char.IsWhiteSpace(test[i]))
                {
                    if (wasInWord)
                    {
                        count++;
                        wasInWord = false;
                    }
                    inWord = false;
                }
                else
                {
                    inWord = true;
                }
            }

            // Check to see if we got out with seeing a word 123123
            if (wasInWord)
            {
                count++;
            }

            return count;
        }
        private void getLocalInstance_Click(object sender, EventArgs e)
        {
            printTextLocal();
        }
        private void getDbInstance_Click(object sender, EventArgs e)
        {
            printTextDb();
        }
        private void ChangeInstance_Click(object sender, EventArgs e)
        {
            try
            {
                int outputvalue;
                if (int.TryParse(textBox1.Text, out outputvalue))
                {
                    ChangeInstanceId(outputvalue);
                    printTextLocal();
                }
                else
                {
                    MessageBox.Show("Enter Valid Number");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Couldnt Change to this instance");
            }
        }
        private void ChangeInstanceId(int outputvalue)
        {
            string folderName = comboBox1.SelectedItem.ToString();
            string fullConfigPath = getConfigPath(folderName);
            string oldInstanceId = getInstance(fullConfigPath).ToString();
            string newInstanceId = outputvalue.ToString();
            setInstance(fullConfigPath, newInstanceId, oldInstanceId);
        }
    }
}
