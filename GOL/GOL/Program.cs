// See https://aka.ms/new-console-template for more information

using GOL;

GameSettings settings = new GameSettings(50, 30, new string[] /*{"  ", " -", " =", " #"}*/ {"  ", " .", " o", " O", " @" }, 80);

GameOfLife game = new GameOfLife(settings, new ExampleGameDrawer());
game.drawGame();
game.run();