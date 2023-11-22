public static class Texts
{
  private static string s_info = "Привет, я - П.И.П. ваш персональный информационный помощник! Я был создан, чтобы помочь вам и ответить на некоторые вопросы!";  
  private static string s_objects = "Наш технопарк оборудован современными технологиями, такими как 3D-принтеры, интерактивные доски, робототехника...";
  private static string s_education = "Наш парк включает в себя две программы обучения: 'Как создать стартап' и 'Про стартап'";
  private static string s_notFound = "Placeholder";

  public enum TextsVariant 
  {
    InfoText,
    ObjectsText,
    EductaionText,
  }

  public static string GetTextFromId(TextsVariant id)
  {
    switch (id)
    {
      case TextsVariant.InfoText:
        return s_info;
      case TextsVariant.ObjectsText:
        return s_objects;
      case TextsVariant.EductaionText:
        return s_education;
      default:
        return s_notFound;
    }
  }
}
