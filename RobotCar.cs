using System;
//Summary
//Create a RoboticCar that moves across a 2D array Grid.
//First project I've actually written in a class but it was a valiant effort on my part to piece it together.

public class RobotCar 
 {
 
 private bool move_about = true;
 private const char SPRAYER_UP   =  '1';
 private const char SPRAYER_DOWN =  '2';
 private const char TURN_LEFT    =  '3';
 private const char TURN_RIGHT   =  '4';
 private const char MOVE_FORWARD =  '5';
 private const char PRINT_FLOOR  =  '6';
 private const char EXIT         =  '7';
 
 private enum SprayerPositions { UP, DOWN } ;
 private enum Directions { NORTH, SOUTH, EAST, WEST };
 
 private SprayerPositions sprayer_positions = SprayerPositions.UP;
 private Directions direction = Directions.EAST;
 
 private bool[,] floor;
 private int current_row;
 private int current_col;
 
 public RobotCar(int rows, int cols)
 {
 Console.WriteLine("RobotCar Winz0r!");
 floor = new bool[rows,cols];
 }
 
 public void PrintMenu()
 {
 Console.WriteLine("\n\n");
 Console.WriteLine("   RobotCar Menu Options");
 Console.WriteLine();
 Console.WriteLine("  1. Sprayer Up");
 Console.WriteLine("  2. Sprayer Down");
 Console.WriteLine("  3. Turn Left");
 Console.WriteLine("  4. Turn Right");
 Console.WriteLine("  5. Move Forward");
 Console.WriteLine("  6. Print Floor");
 Console.WriteLine("  7. Exit");
 Console.WriteLine("\n\n");
 }
 
public void ProcessMenuChoice()
{
   String input = Console.ReadLine();
   
   if(input == String.Empty)
   {
   input = "0";
   }
   switch(input[0])
  {
  case SPRAYER_UP   : SetSprayerUp();
                     break;
  case SPRAYER_DOWN : SetSprayerDown();
                     break;
  case TURN_LEFT   : TurnLeft();
                     break;
  case TURN_RIGHT    : TurnRight();
                     break;
  case MOVE_FORWARD  : MoveForward();
                     break;
  case PRINT_FLOOR  : PrintFloor();
                     break;
  case EXIT         : move_about = false;
                    break;
  default           : PrintErrorMessage();
                    break;
 }
}

public void SetSprayerUp()
{
sprayer_positions = SprayerPositions.UP;
Console.WriteLine("The sprayer is " + sprayer_positions);
}
 
  
public void SetSprayerDown(){
sprayer_positions = SprayerPositions.DOWN;
Console.WriteLine("The sprayer is " + sprayer_positions);
}

public void TurnLeft(){
switch(direction){
      case Directions.NORTH : direction = Directions.WEST;
                              break;
      case Directions.WEST  : direction = Directions.SOUTH;
                              break;
      case Directions.SOUTH : direction = Directions.EAST;
                              break;
	  case Directions.EAST : direction = Directions.NORTH;
                              break;
}

Console.WriteLine("Direction is " + direction);
}

public void TurnRight(){
switch (direction){
case Directions.NORTH : direction = Directions.EAST;
   break;
 
case Directions.EAST : direction =  Directions.SOUTH;
break;

case Directions.SOUTH : direction = Directions.WEST;
break;

case Directions.WEST : direction = Directions.NORTH;
break;
}
Console.WriteLine("Direction is " + direction);
}

public void PrintFloor()
{
for (int i = 0; i < floor.GetLength(0); i++)
{
for (int j = 0; j < floor.GetLength(1); j++)
{
if (floor[i, j])
{
Console.Write('-');
}
else
{
Console.Write('0');
}
}
Console.WriteLine();
}
}

public int GetIncrementsToMove(){
int increments = 0;
String input;

Console.WriteLine("Please enter a number of increments to move: ");
input = Console.ReadLine();

if(input == String.Empty){
increments = 0;
}else{
try{
increments = Convert.ToInt32(input);

}catch(Exception){
increments = 0;
}
}
return increments;
}


public void MoveForward(){
int increments_to_move = GetIncrementsToMove();

switch(sprayer_positions){
case SprayerPositions.UP :
switch (direction){

case Directions.NORTH :
if((current_row - increments_to_move) < 0){
current_row = 0;
}else{
current_row = current_row - increments_to_move;
}
break;

case Directions.SOUTH :
if((current_row + increments_to_move) > (floor.GetLength(1) - 1)){
current_row = (floor.GetLength(1) - 1);
}else{
current_row = current_row + increments_to_move;
}
break;

case Directions.EAST :
if((current_col + increments_to_move) > (floor.GetLength(0) - 1)){
current_col = (floor.GetLength(0) - 1);
}else{
current_col = current_col + increments_to_move;
}
break;
case Directions.WEST :
if((current_col - increments_to_move) < 0) {
current_col = 0;
}else{
current_col = current_col - increments_to_move;
}
break;
}
break;
case SprayerPositions.DOWN:
switch(direction){
case Directions.NORTH :
while((current_row > 0) && (increments_to_move-- > 0)){
floor[current_row--, current_col] = true;
}
break;
case Directions.SOUTH :
while((current_row < floor.GetLength(0) - 1) && (increments_to_move-- > 0)){
floor[current_row++, current_col] = true;
}
break;
case Directions.EAST :
while((current_col < floor.GetLength(1) - 1) && (increments_to_move-- > 0)){
floor[current_row, current_col++] = true;
}
break;
case Directions.WEST :
while((current_col > 0) && (increments_to_move -- > 0)){
floor[current_row, current_col--] = true;
}
break;
}
break;
}
}

public void Run()
{
while (move_about)
{
PrintMenu();
ProcessMenuChoice();
}
}

public void PrintErrorMessage()
{
Console.WriteLine("Please enter a valid RobotCar control menu option!");
}

public static void Main(String[] args){
{
RobotCar rc = new RobotCar(20, 20);
rc.Run();
}
}
}