using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace SerialisationApp;

public class XMLSerialiser : ISerialise

{
    public T DeserialiseFromFile<T>(string filePath)
    {
        Stream fileStream = File.OpenRead(filePath);
        XmlSerializer reader = new XmlSerializer(typeof(T));
        var deserialisedItem = (T)reader.Deserialize(fileStream);

        fileStream.Close();

        return deserialisedItem;
    }

    public void SerialiseToFile<T>(string filePath, T item)
    {
        FileStream fileStream = File.Create(filePath);
        // creating a BinaryFormatter object to sue to serialise the item to the file
        XmlSerializer writer = new XmlSerializer(item.GetType());
        writer.Serialize(fileStream, item);

        fileStream.Close(); //make sure to close else we will end up with a memory leak
    }
}
