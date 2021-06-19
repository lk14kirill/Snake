using SFML.Graphics;
using System.Collections.Generic;

namespace Snake
{
    class Fabric
    {
        private static Fabric instance;
        public static Fabric Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Fabric();
                }
                return instance;
            }
        }

        private List<IUpdatable> objectsToRemove = new List<IUpdatable>();
        private List<CircleObject> objectsToRegister = new List<CircleObject>();
        public void AddToObjectsToRemove(IUpdatable updatable) => objectsToRemove.Add(updatable);
        public void AddToObjectsToRegister(CircleObject circle) => objectsToRegister.Add(circle);
        public void RegisterCachedObjects(UpdatableObjects updatableObjects, DrawableObjects drawable)
        {
            foreach(CircleObject circle in objectsToRegister)
            {
                RegisterDrawableObject(updatableObjects,drawable,circle );
            }
        }
        public void RemoveCachedObjectsAndCreateNew(UpdatableObjects updatableObjects, DrawableObjects drawable)
        {
            foreach (IUpdatable updatable in objectsToRemove)
            {
                UnregisterObject(updatableObjects, drawable, updatable);
                if (updatable is Player)
                    CreatePlayer(updatableObjects, drawable);
                if (updatable is Food)
                    RegisterObject(updatableObjects, drawable, new Food());
            }

            objectsToRemove = new List<IUpdatable>();
        }

        public  void CreatePlayer(UpdatableObjects updatableObjects, DrawableObjects drawableObjects)
        {
            Player newPlayer = new Player();
            RegisterObject(updatableObjects, drawableObjects, newPlayer);
        }

        public void CreateFood(UpdatableObjects updatableObjects, DrawableObjects drawableObjects, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                Food food = new Food();
                RegisterObject(updatableObjects, drawableObjects, food);
            }
        }
        public void RegisterObject(UpdatableObjects updatableObjects,DrawableObjects drawableObjects,IUpdatable updatable)
        {
            if (updatable is IUpdatable)
                updatableObjects.Add(updatable as IUpdatable);
            if (updatable is IDrawable)
                drawableObjects.Add(updatable as IDrawable);
        }
        public void RegisterDrawableObject(UpdatableObjects updatableObjects, DrawableObjects drawableObjects, IDrawable drawable)
        {
            if (drawable is IDrawable)
                drawableObjects.Add(drawable);
        }
        public void UnregisterObject(UpdatableObjects updatableObjects, DrawableObjects drawableObjects, IUpdatable updatable)
        {
            if (updatable is IUpdatable)
                updatableObjects.Remove(updatable as IUpdatable);
            if (updatable is IDrawable)
                drawableObjects.Remove(updatable as IDrawable);
        }
        public void UnregisterDrawableObject(UpdatableObjects updatableObjects, DrawableObjects drawableObjects, IDrawable drawable)
        {
            if (drawable is IDrawable)
                drawableObjects.Remove(drawable);
        }
    }
}
