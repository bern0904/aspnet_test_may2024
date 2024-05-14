using MyData.Data;
using MySharedLib.Interfaces;
using System.Security.AccessControl;
using System.Xml.Serialization;

namespace MyData.Services
{
    /// <summary>
    /// Service class for data storage implementation through XML file
    /// </summary>
    public class XMLFileService: IFileService
    {
        private string _filePath;

        public XMLFileService()
        {
            _filePath = Path.Combine(Path.GetTempPath(), "MyDataDB");

            if (!Directory.Exists(_filePath))
                Directory.CreateDirectory(_filePath);
        }

        public bool Save<T>(int? id, T data)
        {
            if (id == 0)
                return false;

            if (data == null)
                return false;

            var path = Path.Combine(_filePath, data.GetType().Name.ToString());
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var fileName = Path.Combine(path, $"{id}.xml");
            var serializedData = string.Empty;

            using (var stringWriter = new StringWriter())
            {
                using (var streamWriter = new StreamWriter(fileName))
                {
                    var serializer = new XmlSerializer(data.GetType());
                    serializer.Serialize(stringWriter, data);
                    serializedData = stringWriter.ToString();

                    streamWriter.Write(serializedData);
                }
            }

            return File.Exists(fileName);
        }

        public bool Delete<T>(int? id, T data)
        {
            if (id == 0)
                return false;

            if (data == null)
                return false;

            var path = Path.Combine(_filePath, data.GetType().Name.ToString());
            if (!Directory.Exists(path))
                return false;

            var fileName = Path.Combine(path, $"{id}.xml");

            File.Delete(fileName);

            return !File.Exists(fileName);
        }

        public T? Find<T>(int? id, T data)
        {
            if (id == 0)
                return default;

            if (data == null)
                return default;

            var path = Path.Combine(_filePath, data.GetType().Name.ToString());
            if (!Directory.Exists(path))
                return default;

            var searchedFile = Directory.GetFiles(path, $"{id}.xml");
            if (searchedFile.Any())
            {
                using (var streamReader = new StreamReader(searchedFile[0]))
                {
                    var serializer = new XmlSerializer(data.GetType());
                    var deserializedObject = serializer.Deserialize(streamReader);

                    return deserializedObject == null ? default : (T)deserializedObject;
                }
            }
            else return default;
        }

        public int GetNextId<T>(T data)
        {
            if (data == null)
                return 0;

            var path = Path.Combine(_filePath, data.GetType().Name.ToString());
            if (!Directory.Exists(path))
                return 1;

            var searchedFiles = Directory.GetFiles(path, $"*.xml");
            if (!searchedFiles.Any())
            {
                return searchedFiles.Count() + 1;
            }
            else
                return 1;
        }
    }
}
