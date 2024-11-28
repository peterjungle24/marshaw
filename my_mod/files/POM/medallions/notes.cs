/*  IDrawable


public void InitiateSprites(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam)
{ }
public void DrawSprites(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float Float, Vector2 camPos)
{ }
public void ApplyPalette(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, RoomPalette pal)
{ }
public void AddToContainer(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, FContainer fContainer)
{ }

*/
/*  POM

public class DoubleJ_Medallion_managedData : ManagedData
{

    public string stun)skill;

    public DoubleJ_Medallion_managedData(PlacedObject own) : base(own, null)
    {

    }
}

public class DoubleJ_Medallion_UAD : UpdatableAndDeletable
{
    public DoubleJ_Medallion_UAD(Room room, PlacedObject placed_object)
    {
    }
}

public class DoubleJ_Medallion_repr : ManagedRepresentation
{
    public DoubleJ_Medallion_repr(PlacedObject.MedalType type, ObjectsPage object_page, PlacedObject placed_object) : base(type, object_page, placed_object)
    {
    }
}

*/
/*  IDrawable - UAD

 ///IDRAWABLE
public void InitiateSprites(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam)
{
    sLeaser.sprites = new FSprite[1];
    sLeaser.sprites[0] = new FSprite("Futile_White", true);

    sLeaser.sprites[0].scale = 10f;

    Debug.Log("init sprites");
    AddToContainer(sLeaser, rCam, null);
}


public void DrawSprites(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float Float, Vector2 camPos)
{
    sLeaser.sprites[0].field_x = camPos.field_x;
    sLeaser.sprites[0].field_y = camPos.field_y;

    Debug.Log("draw sprites");
}
public void ApplyPalette(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, RoomPalette pal)
{
    Debug.Log("apply palette");
}
public void AddToContainer(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, FContainer fContainer)
{
    fContainer ??= rCam.ReturnFContainer("Items");

    foreach (FSprite fsprite in sLeaser.sprites)
    {
        fContainer.AddChild(fsprite);
    }
    Debug.Log("add to container");
}
  
*/