(function() {
  const apiUrl = "http://localhost:9000";
  const fieldSize = 8;
  const history = [];

  let steps = [];
  let field = [
    [".", "b", ".", "b", ".", "b", ".", "b"],
    ["b", ".", "b", ".", "b", ".", "b", "."],
    [".", "b", ".", "b", ".", "b", ".", "b"],
    [".", ".", ".", ".", ".", ".", ".", "."],
    [".", ".", ".", ".", ".", ".", ".", "."],
    ["w", ".", "w", ".", "w", ".", "w", "."],
    [".", "w", ".", "w", ".", "w", ".", "w"],
    ["w", ".", "w", ".", "w", ".", "w", "."]
  ];

  let fieldCanvas,
    context,
    canvasWidth,
    canvasHeight,
    cellHeight,
    cellWidth,
    currentChecker;

  $(document).ready(function() {
    fieldCanvas = $("#canvas")[0];
    context = fieldCanvas.getContext("2d");

    canvasWidth = fieldCanvas.width;
    canvasHeight = fieldCanvas.height;

    cellHeight = canvasHeight / fieldSize;
    cellWidth = canvasWidth / fieldSize;

    drawField();
    drawGame();

    fieldCanvas.addEventListener("mousedown", function(e) {
      let position = getMousePosition(e);
      addStep(position);
      currentChecker = field[position.x][position.y];

      fieldCanvas.addEventListener("mousemove", omMouseMove);

      return false;
    });

    fieldCanvas.addEventListener("mouseup", function(e) {
      let position = getMousePosition(e);
      addStep(position);

      fieldCanvas.removeEventListener("mousemove", omMouseMove);

      playSteps(0, 1);
    });

    $("#back")[0].addEventListener("click", function() {
      field = history.pop();
      drawGame();
    });
  });

  function omMouseMove(e) {
    let position = getMousePosition(e);
    let x = position.x;
    let y = position.y;

    if ((x % 2 == 0 && y % 2 == 1) || (x % 2 == 1 && y % 2 == 0)) {
      context.fillStyle = "rgba(0,255,0,0.1)";
      context.fillRect(
        y * cellHeight,
        x * cellWidth,
        cellWidth - 1,
        cellHeight - 1
      );
    }
  }

  function drawField() {
    let horizontalLine = 0;
    for (let i = 1; i < fieldSize; i++) {
      horizontalLine += cellHeight;
      context.moveTo(0, horizontalLine);
      context.lineTo(canvasWidth, horizontalLine);
    }

    let verticalLine = 0;
    for (let i = 1; i < fieldSize; i++) {
      verticalLine += cellWidth;
      context.moveTo(verticalLine, 0);
      context.lineTo(verticalLine, canvasHeight);
    }

    context.stroke();
  }

  function drawGame() {
    for (let i = 0; i < fieldSize; i++) {
      for (let j = 0; j < fieldSize; j++) {
        drawCell(i, j);
      }
    }
  }

  function drawCell(x, y) {
    context.fillStyle =
      (x % 2 == 0 && y % 2 == 1) || (x % 2 == 1 && y % 2 == 0)
        ? "#b46a3d"
        : "#e0a86b";
    context.fillRect(
      y * cellHeight,
      x * cellWidth,
      cellWidth - 1,
      cellHeight - 1
    );

    switch (field[x][y]) {
      case "b":
        drawCheck("#000000", x, y);
        break;
      case "B":
        drawKing("#000000", x, y);
        break;
      case "w":
        drawCheck("#ffffff", x, y);
        break;
      case "W":
        drawKing("#ffffff", x, y);
        break;
      case ".":
      default:
        break;
    }
  }

  function drawCheck(color, x, y) {
    context.fillStyle = color;
    context.beginPath();
    context.arc(y * cellHeight + 25, x * cellWidth + 25, 20, 0, 2 * Math.PI);
    context.fill();
  }

  function drawKing(color, x, y) {
    drawCheck(color, x, y);

    context.fillStyle = "#ff0000";
    context.beginPath();
    context.arc(y * cellHeight + 25, x * cellWidth + 25, 5, 0, 2 * Math.PI);
    context.fill();
  }

  function addStep(position) {
    steps.push(position);
  }

  function playSteps(start, next) {
    let from = steps[start];
    let to = steps[next];
    if (!to) {
      steps = [];
      return;
    }

    setTimeout(function() {
      moveCheck(from, to);
      playSteps(next, next + 1);
    }, 500);
  }

  function moveCheck(from, to) {
    let newField = mutateField();
    newField[from.x][from.y] = ".";
    newField[to.x][to.y] = currentChecker;
    history.push(field);
    field = newField;
    drawGame();
  }

  function mutateField() {
    let newField = [];
    for (let i = 0; i < fieldSize; i++) {
      let row = [];
      for (let j = 0; j < fieldSize; j++) {
        row.push(field[i][j]);
      }
      newField.push(row);
    }

    return newField;
  }

  function getMousePosition(e) {
    let xMouse = e.clientX;
    let yMouse = e.clientY;

    xMouse -= canvas.offsetLeft;
    yMouse -= canvas.offsetTop;

    return {
      x: Math.floor(yMouse / cellHeight),
      y: Math.floor(xMouse / cellWidth)
    };
  }

  function isEnd() {
    let white = 0;
    let black = 0;

    for (let i = 0; i < fieldSize; i++) {
      for (let j = 0; j < fieldSize; j++) {
        if (field[i][j] === "w" || field[i][j] === "W") {
          white++;
        }

        if (field[i][j] === "b" || field[i][j] === "B") {
          black++;
        }
      }
    }

    return white === 0 || black === 0;
  }
})();
