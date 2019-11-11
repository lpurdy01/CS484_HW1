// vec3.h
// 11/10/2019
// Levi Purdy
// Refrencing from "Ray Tracing in a Weekend"

#pragma once

#include <math.h>
#include <stdlib.h>
#include <iostream>


class vec3
{
public:
	vec3() {}
	vec3(float t) 
	{
		e[0] = t; e[1] = t; e[2] = t;
	}
	vec3(float e0, float e1, float e2)
	{
		e[0] = e0; e[1] = e1; e[2] = e2;
	}

	float x() const { return e[0]; }
	float y() const { return e[1]; }
	float z() const { return e[2]; }
	float r() const { return e[0]; }
	float g() const { return e[1]; }
	float b() const { return e[2]; }

	const vec3& operator+() const { return *this; }
	vec3 operator-() const { return vec3(-e[0], -e[1], -e[2]); }
	float operator[](int i) const { return e[i]; }
	float& operator[](int i) { return e[i]; };

	vec3& operator+=(const vec3& v2);
	vec3& operator-=(const vec3& v2);
	vec3& operator*=(const vec3& v2);
	vec3& operator/=(const vec3& v2);
	vec3& operator*=(const float t);
	vec3& operator/=(const float t);

	friend vec3 operator*(const vec3& v1, const vec3& v2);
	friend vec3 operator+(const vec3& v1, const vec3& v2);
	friend vec3 operator-(const vec3& v1, const vec3& v2);
	friend vec3 operator/(const vec3& v1, const vec3& v2);

	friend vec3 unit_vector(vec3 v);


	float length() const {
		return sqrt(e[0] * e[0] + e[1] * e[1] + e[2] * e[2]);
	}

	float squared_length() const {
		return e[0] * e[0] + e[1] * e[1] + e[2] * e[2];
	}

	void make_unit_vector();


	float e[3];
};

