#include "pch.h"

bool _isFirstMove;
bool _isFirstMouseMove;
bool _cameraSelector;
float _cameraSpeed;
float _sensitivity;
std::vector<float> _player_Position;
std::vector<float> _front;
std::vector<float> _right;
std::vector<float> _up;
std::vector<float> _mouse_Position;
float _pitch;
float _yaw;
float _roll;

Avril_FSD::Player::Player()
{
	_isFirstMove = true;
	_isFirstMouseMove = false;
	_player_Position = { 0.0, 0.0, 0.0 };
	_front = { 0.0, 0.0, 0.0 };
	_right = { 0.0, 0.0, 0.0 };
	_up = { 0.0, 0.0, 0.0 };
	_mouse_Position = { 0.0, 0.0 };
	_cameraSelector = false;
	_cameraSpeed = 1.5f;
	_sensitivity = 0.2f;
}
Avril_FSD::Player::~Player()
{
}

bool Avril_FSD::Player::Get_isFirstMove()
{
	return _isFirstMove;
}
bool Avril_FSD::Player::Get_isFirstMouseMove()
{
	return _isFirstMouseMove;
}
bool Avril_FSD::Player::Get_cameraSelector()
{
	return _cameraSelector;
}
float Avril_FSD::Player::Get_cameraSpeed()
{
	return _cameraSpeed;
}
float Avril_FSD::Player::Get_sensitivity()
{
	return _sensitivity;
}
std::vector<float> Avril_FSD::Player::Get_player_Position()
{
	return _player_Position;
}
std::vector<float> Avril_FSD::Player::Get_Front()
{
	return _front;
}
std::vector<float> Avril_FSD::Player::Get_Right()
{
	return _right;
}
std::vector<float> Avril_FSD::Player::Get_Up()
{
	return _up;
}
std::vector<float> Avril_FSD::Player::Get_mouse_Position()
{
	return _mouse_Position;
}

float Avril_FSD::Player::Get_pitch()
{
	return _pitch;
}

float Avril_FSD::Player::Get_yaw()
{
	return _yaw;
}

float Avril_FSD::Player::Get_roll()
{
	return _roll;
}

void Avril_FSD::Player::Set_isFirstMove(bool value)
{
	_isFirstMove = value;
}

void Avril_FSD::Player::Set_isFirstMouseMove(bool value)
{
	_isFirstMouseMove = value;
}

void Avril_FSD::Player::Set_cameraSpeed(float cameraSpeed)
{
	_cameraSpeed = cameraSpeed;
}

void Avril_FSD::Player::Set_sensitivity(float sensitivity)
{
	_sensitivity = sensitivity;
}

void Avril_FSD::Player::Set_player_Position(std::vector<float> position)
{

	_player_Position = position;
}

void Avril_FSD::Player::Set_front(std::vector<float> front)
{
	_front = front;
}

void Avril_FSD::Player::Set_right(std::vector<float> right)
{
	_right = right;
}

void Avril_FSD::Player::Set_up(std::vector<float> up)
{
	_up = up;
}

void Avril_FSD::Player::Set_mouse_Position(std::vector<float> mousePosition)
{
	_mouse_Position = mousePosition;
}

void Avril_FSD::Player::Set_pitch(float pitch)
{
	_pitch = pitch;
}

void Avril_FSD::Player::Set_yaw(float yaw)
{
	_yaw = yaw;
}

void Avril_FSD::Player::Set_roll(float roll)
{
	_roll = roll;
}
