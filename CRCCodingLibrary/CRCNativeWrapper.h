#pragma once
#include "CRC.h"

#define LIBRARY_EXPORT __declspec(dllexport)

extern "C" LIBRARY_EXPORT tmpCRC::CRC * new_CRC(const char* msg, const char* chosenCRC);
extern "C" LIBRARY_EXPORT void delete_CRC(tmpCRC::CRC * instance);
extern "C" LIBRARY_EXPORT int GetXORListLength(tmpCRC::CRC * instance);
extern "C" LIBRARY_EXPORT std::string GetXORResult(tmpCRC::CRC * instance, int wichOne);