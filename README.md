# Chess

A C# chess engine with a console UI and two AI opponents (Minimax and Alpha-Beta pruning), built on .NET 8. Created for the **IMN236** course.

> Repo: [`cdoresca/chess`](https://github.com/cdoresca/chess)

## What it does

The game runs entirely in the console: pieces are drawn on an 8×8 board, and each side is controlled by a `Player`. By default, both White and Black are `Agent`s driven by an **Alpha-Beta search** (`chess/IA/AlphaBeta.cs`), so out of the box the program plays itself. A human-controlled `Player` is also implemented (arrow keys to move the cursor, Enter to select a piece and then its destination) and can be swapped in by editing `Game.cs`.

## Features

- **Full piece set** with movement rules: Pion (pawn), Tour (rook), Cheval (knight), Fou (bishop), Reine (queen), Roi (king) (`chess/piece/`)
- **Game state management**: legal move generation, check/checkmate/stalemate detection (`GameState.cs`, `Board.cs`)
- **Two AI search algorithms**:
  - `MinMax.cs` — plain minimax search
  - `AlphaBeta.cs` — minimax with alpha-beta pruning (used by default, depth 3)
- **Console rendering**: board and pieces drawn to the console window, with move/selection highlighting (`chess/UI/`, `chess/UI/pieceUI/`)
- **Keyboard controls**: arrow keys to navigate the board, Enter to select/move
- **Utility data structures**: custom graph and list implementations (`chess/util/`)

## Project structure

```
chess/
├── Agent.cs             # AI-controlled player (wraps a search Mode)
├── Board.cs              # Board state / piece placement
├── Case.cs                # A single board square
├── Game.cs                # Sets up pieces, players, and runs the game loop
├── GameState.cs           # Move legality, check/checkmate/stalemate logic
├── IA/
│   ├── Mode.cs             # Base class for AI search strategies
│   ├── MinMax.cs           # Minimax search
│   └── AlphaBeta.cs        # Minimax with alpha-beta pruning
├── Move.cs                # Represents a move (from/to coordinates)
├── PieceBase.cs           # Base class for all pieces
├── PlayerState.cs         # Per-player piece tracking
├── Program.cs             # Entry point
├── UI/
│   ├── BoardUI.cs          # Console rendering of the board
│   ├── CaseUI.cs           # Console rendering of a square
│   ├── ConsoleUI.cs        # Top-level console UI / move display
│   ├── Control.cs          # Keyboard input handling & agent move display
│   ├── Player.cs           # Base player (keyboard-controlled by default)
│   └── pieceUI/            # Per-piece console rendering
├── Windows.cs              # Console window helper
├── piece/                  # Pion, Tour, Cheval, Fou, Reine, Roi
└── util/                   # Graph.cs, Liste.cs — custom data structures
```

## Requirements

- **.NET 8 SDK**
- A terminal that supports `Console.ReadKey` / ANSI console colors (Windows Terminal, or a compatible terminal on Linux/macOS)

## Building & running

```bash
git clone https://github.com/cdoresca/chess.git
cd chess
dotnet build chess.sln
dotnet run --project chess
```

Or open `chess.sln` in Visual Studio 2022 and run the `chess` project directly.

By default the game starts with **both sides controlled by the Alpha-Beta AI** and plays to checkmate or stalemate automatically. To play as a human against the AI (or against another human), edit the player setup in `Game.cs`:

```csharp
// white = new Player(Color.WHITE, console);              // human, keyboard-controlled
white = new Agent(Color.WHITE, console, new AlphaBeta(Color.WHITE)); // AI

black = new Agent(Color.BLACK, console, new AlphaBeta(Color.BLACK)); // AI
```

Swap either line to `new Player(color, console)` for keyboard control, or use `new Agent(color, console, new MinMax(color))` to use plain minimax instead of alpha-beta.

## Controls (human player)

- **Arrow keys** — move the selection cursor
- **Enter** — select a piece, then select a destination square to move it (press Enter again on the same square to deselect)

## Roadmap / possible next steps

- [ ] Expose a way to choose player type (human/AI) and search depth without editing code
- [ ] Add castling, en passant, and pawn promotion if not already fully covered
- [ ] Add a graphical UI as an alternative to the console renderer
- [ ] Tune AI evaluation function beyond win/loss/draw scoring for stronger midgame play
