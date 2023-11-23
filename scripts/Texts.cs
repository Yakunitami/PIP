public static class Texts
{
  private static string s_info = "ГАУ «Технопарк «Якутия», является уникальным объектом инновационной инфраструктуры региона и призван обеспечивать территориальную концентрацию технологических и интеллектуальных ресурсов для ускоренного инновационного развития основных отраслей экономики.";  
  private static string s_objects = "Наш технопарк оборудован современными технологиями, такими как 3D-принтеры, интерактивные доски, робототехника...";
  private static string s_education = " У Вас давно появилась инновационная идея для реализации? Интересовало как внедряются новые технологии? Побывав на экскурсии по Технопарку Якутия, Вы сможете получить ответы на эти вопросы.Именно здесь молодые специалисты разрабатывают и внедряют новые элементы инфраструктуры, продвигают инновационные проекты на российские и зарубежные рынки. ";
  private static string s_story = "Площадка была создана Распоряжением Президента Республики Саха (Якутия) №998-РП от «28» декабря 2011 года. Здесь туристы смогут почувствовать сочетание образовательной, научно-исследовательской и производственной сфер. Каждому будет интересно побывать на площадке, которая входит в ТОП-10 технопарков России, по рейтингу журнала «РБК». ";
  private static string s_notFound = "Placeholder";

  public enum TextsVariant 
  {
    InfoText,
    ObjectsText,
    EductaionText,
    StoryText,
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
      case TextsVariant.StoryText:
        return s_story;
      default:
        return s_notFound;
    }
  }
}
