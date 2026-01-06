
namespace EksamensSkabelon
{
    public interface IClassRepo
    {
        Class1 Add(Class1 item);
        Class1? Delete(int id);
        List<Class1> GetAll();
        Class1? GetById(int id);
    }
}