public static class ModuleTexts
{
  private static string s_first = "Добро пожаловать в отдел робототехники, тут вы можете увидеть...";  
  private static string s_second = "Наш технопарк оборудован современными технологиями, такими как 3D-принтеры, интерактивные доски, робототехника...";
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