#include "pch.h"

bool _firstMove;

bool _isPlayerMoved;
std::vector<float> _player_Position;
std::vector<float> _Front;
std::vector<float> _Right;
std::vector<float> _Up;

bool _isMouseChanged;
std::vector<float> _mouse_Position;

float _cameraSpeed;
float _sensitivity;

Avril_FSD::Player::Player()
{
	_firstMove = true;
	_isPlayerMoved = false;
	_player_Position = { 0.0, 0.0, 0.0 };
	_Front = { 0.0, 0.0, 0.0 };
	_Right = { 0.0, 0.0, 0.0 };
	_Up = { 0.0, 0.0, 0.0 };
	_isMouseChanged = false;
	_mouse_Position = { 0.0, 0.0 };
	_cameraSpeed = 1.5f;
	_sensitivity = 0.2f;
}
Avril_FSD::Player::~Player()
{
}

bool Avril_FSD::Player::Get_isMouseChanged()
{
	return _isMouseChanged;
}
bool Avril_FSD::Player::Get_isFirstMove()
{
	return _firstMove;
}
std::vector<float> Avril_FSD::Player::Get_Front()
{
	return _Front;
}
std::vector<float> Avril_FSD::Player::Get_Right()
{
	return _Right;
}
std::vector<float> Avril_FSD::Player::Get_Up()
{
	return _Up;
}
std::vector<float> Avril_FSD::Player::Get_MousePos()
{
	return _mouse_Position;
}
std::vector<float> Avril_FSD::Player::Get_PlayerPosition()
{
	return _player_Position;
}
float Avril_FSD::Player::Get_CameraSpeed()
{
	return _cameraSpeed;
}
float Avril_FSD::Player::Get_Sensativity()
{
	return _sensitivity;
}
void Avril_FSD::Player::Set_isFirstMove(bool value)
{
	_firstMove = value;
}
void Avril_FSD::Player::Set_MousePos(std::vector<float> value)
{
	_mouse_Position = value;
}
void Avril_FSD::Player::Set_PlayerPosition(std::vector<float> value)
{
	_player_Position = value;
}