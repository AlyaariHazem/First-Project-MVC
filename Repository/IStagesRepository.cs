using Backend.Models;
using FirstProjectWithMVC.ViewModels;

namespace FirstProjectWithMVC.Repository;

public interface IStagesRepository
{
    public void Add(AddStageViewModel obj);  
     public void Update(Stage obj);
     public void Delete(int obj);
     public List<Stage> GetAll();
     public Stage GetById(int id);
     public void Save();
    public List<StagesViewModel> DisplayStages();
    
}
