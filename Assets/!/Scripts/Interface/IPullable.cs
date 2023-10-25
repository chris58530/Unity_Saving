using UnityEngine;

public interface IPullable
{
    bool isPulling { get; set; }
    void Pull(Vector3 target);

    bool HasMarked { get; set; }
    void SetMark(bool isMark);
}