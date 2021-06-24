using System;
using SFML.System;
using SFML.Graphics;
using SFML.Window;
using System.Threading;

namespace Snake
{
    class Game
        {
            private double time;
            private float totalTimeBeforeUpdate = 0f;
            private float previousTimeElapsed = 0f;
            private float deltaTime = 0f;
            private float totalTimeElapsed = 0f;

            private ThreadManager threadManager = new ThreadManager();
            private DrawableObjects drawableObjects = new DrawableObjects();
            private UpdatableObjects updatableObjects = new UpdatableObjects();
            private Clock clock = new Clock();
            private RenderWindow window = new RenderWindow(new VideoMode(Constants.windowX, Constants.windowY), "Game window");

            public void GameCycle()
            {
                Init();
                while (window.IsOpen)
                {
                  DoCycle();
                }
            }
            private void Init()
            {
                WindowSetup();
                CreateObjects();
            threadManager.InitAnimationThread(updatableObjects.GetPlayer());
            }
            private void DoCycle()
            {
                totalTimeElapsed = clock.ElapsedTime.AsSeconds();
                deltaTime = totalTimeElapsed - previousTimeElapsed;
                previousTimeElapsed = totalTimeElapsed;


                totalTimeBeforeUpdate += deltaTime;
              

                if (totalTimeBeforeUpdate >= Constants.TIME_UNTIL_UPDATE)
                {
                    CycleStep();
                }
            }
            private void CycleStep()
            {
              time = clock.ElapsedTime.AsMicroseconds();
              clock.Restart();
              time /= 800;

              if (InputManager.WasPaused())
              {
                  time = 0;
              }
              window.Clear(Color.White);
               window.DispatchEvents();

               updatableObjects.Update(InputManager.GetKeyboardInput(), 
                                       updatableObjects.GetFood(), 
                                      (float)time, 
                                       updatableObjects.GetPlayer(),
                                       InputManager.WasPaused());
               Fabric.Instance.RemoveCachedObjectsAndCreateNew(updatableObjects, drawableObjects);
               Fabric.Instance.RegisterCachedObjects(updatableObjects, drawableObjects);

               drawableObjects.Draw(window);
               window.Display();
            }

            private void CreateObjects()
            {
               PlayerText text = new PlayerText();
               Fabric.Instance.CreateFood(updatableObjects, drawableObjects, 1);
               Fabric.Instance.CreatePlayer(updatableObjects,drawableObjects);
               Fabric.Instance.RegisterObject(updatableObjects, drawableObjects, text);
               text.Initialize(updatableObjects.GetPlayer().GetGO().OutlineColor);
            }
            private void WindowSetup()
            {
                window.Closed += WindowClosed;
                window.KeyPressed += InputManager.OnKeyPressed;
            }
            private void WindowUnsubscribe()
            {
                 window.Closed -= WindowClosed;
                 window.KeyPressed -= InputManager.OnKeyPressed;
            }
            private void WindowClosed(object sender, EventArgs e)
            {
                RenderWindow w = (RenderWindow)sender;
                WindowUnsubscribe();
                w.Close();
            }    
    }

}
