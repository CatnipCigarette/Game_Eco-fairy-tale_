using UnityEngine;

public class TrashCan : MonoBehaviour
{
    public string acceptedTrashTag; // Тег, принимаемый мусоркой

    public bool AcceptsTrashTag(string trashTag)
    {
        return trashTag == acceptedTrashTag;
    }

    public bool RejectsTrashTag(string trashTag)
    {
        // Здесь вам нужно реализовать свою логику проверки на неправильную мусорку.
        // Возвращайте true, если мусорка не принимает указанный тип мусора.
        // Возвращайте false, если мусорка принимает указанный тип мусора.

        // Пример реализации, сравнивающей теги мусора и мусорки:
        if (trashTag == "Paper" && gameObject.tag != "Paper")
        {
            return true; // Мусорка не принимает стекло.
        }

        if (trashTag == "Glass" && gameObject.tag != "Glass")
        {
            return true; // Мусорка не принимает стекло.
        }

        if (trashTag == "Metal" && gameObject.tag != "Metal")
        {
            return true; // Мусорка не принимает стекло.
        }

        if (trashTag == "Organ" && gameObject.tag != "Organ")
        {
            return true; // Мусорка не принимает стекло.
        }

        if (trashTag == "Electro" && gameObject.tag != "Electro")
        {
            return true; // Мусорка не принимает стекло.
        }

        if (trashTag == "Plastic" && gameObject.tag != "Plastic")
        {
            return true; // Мусорка не принимает стекло.
        }

        // Добавьте дополнительные условия для проверки других типов мусора и мусорок.

        return false; // Мусорка принимает указанный тип мусора.
    }

}
