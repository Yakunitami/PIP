public static class ModuleTexts
{    
  private static string s_first = "Добро пожаловать в отдел робототехники, здесь специалисты разрабатывают и создают проекты Искуственного Интелекта";  
  private static string s_second = "Это отдел биотехнологии, основной целью которого является промышленное использование биологических процессов";
  private static string s_notFound = "Placeholder";

  public enum ModuleVariant
  {
    first,
    second,
  }

  public static string GetModuleTextFromId(ModuleVariant id)
  {
    switch (id)
    {
      case ModuleVariant.first:
        return s_first;
      case ModuleVariant.second:
        return s_second;
      default:
        return s_notFound;
    }
  }
}