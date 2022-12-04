using Business.Abstarct;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

ArticleManager articleManager = new ArticleManager(new EfArticleDal());

var result = articleManager.GetAll();
if (result.Success==true)
{
    foreach (var item in result.Data)
    {
        Console.WriteLine(item.Title);
    }
}
else
{
    Console.WriteLine(result.Message);
}
