#pragma once
#include "ProcessInput.h"

#define LIBRARY_EXPORT __declspec(dllexport)

extern "C" LIBRARY_EXPORT ProcessInput* newProcessInputObject()
