using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;
using Avril.ClientAssembly.Graphics.Cameras;
using Avril.ClientAssembly.Graphics.GameObjects;
using Avril.ClientAssembly.Graphics.Renderables;

namespace Avril.ClientAssembly.Graphics
{
    public sealed class MainWindow : GameWindow
    {
        private readonly string _title;
        private GameObjectFactory _gameObjectFactory;
        private readonly List<AGameObject> _gameObjects = new List<AGameObject>();
        private double _time;
        private readonly Color4 _backColor = new Color4(0.1f, 0.1f, 0.3f, 1.0f);
        private Matrix4 _projectionMatrix;
        private float _fov = 45f;
        private ShaderProgram _texturedProgram;
        private ShaderProgram _solidProgram;
        private KeyboardState _lastKeyboardState;
        private Spacecraft _player;
        private int _score;
        private bool _gameOver;
        private Bullet.BulletType _bulletType;
        private Bullet _lastBullet;
        private bool _useFirstPerson = true;
        private ICamera _camera;
        public MainWindow()
            : base(750, // initial width
                500, // initial height
                GraphicsMode.Default,
                "",  // initial title
                GameWindowFlags.Fullscreen,
                DisplayDevice.Default,
                4, // OpenGL major version
                5, // OpenGL minor version
                GraphicsContextFlags.ForwardCompatible)
        {
            _title += "dreamstatecoding.blogspot.com: OpenGL Version: " + GL.GetString(StringName.Version);
        }
        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            CreateProjection();
        }


        protected override void OnLoad(EventArgs e)
        {
            Debug.WriteLine("OnLoad");
            VSync = VSyncMode.Off;
            CreateProjection();
            _solidProgram = new ShaderProgram();
            _solidProgram.AddShader(ShaderType.VertexShader, @"Components\Shaders\1Vert\simplePipeVert.c");
            _solidProgram.AddShader(ShaderType.FragmentShader, @"Components\Shaders\5Frag\simplePipeFrag.c");
            _solidProgram.Link();

            _texturedProgram = new ShaderProgram();
            _texturedProgram.AddShader(ShaderType.VertexShader, @"Components\Shaders\1Vert\simplePipeTexVert.c");
            _texturedProgram.AddShader(ShaderType.FragmentShader, @"Components\Shaders\5Frag\simplePipeTexFrag.c");
            _texturedProgram.Link();
            
            var models = new Dictionary<string, ARenderable>();
            models.Add("Wooden", new MipMapGeneratedRenderObject(new IcoSphereFactory().Create(3), _texturedProgram.Id, @"Components\Textures\wooden.png", 8));
            models.Add("Golden", new MipMapGeneratedRenderObject(new IcoSphereFactory().Create(3), _texturedProgram.Id, @"Components\Textures\golden.bmp", 8));
            models.Add("Asteroid", new MipMapGeneratedRenderObject(new IcoSphereFactory().Create(3), _texturedProgram.Id, @"Components\Textures\moonmap1k.jpg", 8));
            models.Add("Spacecraft", new MipMapGeneratedRenderObject(RenderObjectFactory.CreateTexturedCube6(1, 1, 1), _texturedProgram.Id, @"Components\Textures\spacecraft.png", 8));
            models.Add("Gameover", new MipMapGeneratedRenderObject(RenderObjectFactory.CreateTexturedCube6(1, 1, 1), _texturedProgram.Id, @"Components\Textures\gameover.png", 8));
            models.Add("Bullet", new MipMapGeneratedRenderObject(new IcoSphereFactory().Create(3), _texturedProgram.Id, @"Components\Textures\dotted.png", 8));

            //models.Add("TestObject", new TexturedRenderObject(RenderObjectFactory.CreateTexturedCube(1, 1, 1), _texturedProgram.Id, @"Components\Textures\asteroid texture one side.jpg"));
            //models.Add("TestObjectGen", new MipMapGeneratedRenderObject(RenderObjectFactory.CreateTexturedCube(1, 1, 1), _texturedProgram.Id, @"Components\Textures\asteroid texture one side.jpg", 8));
            //models.Add("TestObjectPreGen", new MipMapManualRenderObject(RenderObjectFactory.CreateTexturedCube(1, 1, 1), _texturedProgram.Id, @"Components\Textures\asteroid texture one side mipmap levels 0 to 8.bmp", 9));

            _gameObjectFactory = new GameObjectFactory(models);

            //_player = _gameObjectFactory.CreateSpacecraft();
            //_gameObjects.Add(_player);
           // _gameObjects.Add(_gameObjectFactory.CreateAsteroid());
            //_gameObjects.Add(_gameObjectFactory.CreateGoldenAsteroid());
            //_gameObjects.Add(_gameObjectFactory.CreateWoodenAsteroid());

            _camera = new StaticCamera();

            CursorVisible = true;

            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            GL.PatchParameter(PatchParameterInt.PatchVertices, 3);
            GL.PointSize(3);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.CullFace);
            Closed += OnClosed;
            Debug.WriteLine("OnLoad .. done");
        }
        
        private void OnClosed(object sender, EventArgs eventArgs)
        {
            Exit();
        }

        public override void Exit()
        {
            Debug.WriteLine("Exit called");
            _gameObjectFactory.Dispose();
            _solidProgram.Dispose();
            _texturedProgram.Dispose();
            base.Exit();
        }
        
        private void CreateProjection()
        {
            
            var aspectRatio = (float)Width/Height;
            _projectionMatrix = Matrix4.CreatePerspectiveFieldOfView(
                _fov*((float) Math.PI/180f), // field of view angle, in radians
                aspectRatio,                // current window aspect ratio
                0.1f,                       // near plane
                4000f);                     // far plane
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            _time += e.Time;
            _camera.Update(_time, e.Time);
            HandleKeyboard(e.Time);
        }

        private void HandleKeyboard(double dt)
        {
            var keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Key.Escape))
            {
                Exit();
            }
            _lastKeyboardState = keyState;
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            Title = $"{_title}: FPS:{1f / e.Time:0000.0}, obj:{_gameObjects.Count}, score:{_score}";
            GL.ClearColor(Color.Black);// _backColor);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            int lastProgram = -1;
            foreach (var obj in _gameObjects)
            {
                var program = obj.Model.Program;
                if (lastProgram != program)
                    GL.UniformMatrix4(20, false, ref _projectionMatrix);
                lastProgram = obj.Model.Program;
                obj.Render(_camera);

            }
            SwapBuffers();
        }
        
    }
}
