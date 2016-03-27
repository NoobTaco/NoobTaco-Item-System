using UnityEngine;

public interface IISDatabaseObject
{
    string Name { get; set; }
    Sprite Icon { get; set; }
    void Clone(IISDatabaseObject item);
    void OnGUI();
}
