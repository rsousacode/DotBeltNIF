cmake_minimum_required(VERSION 3.30)
project(DotBeltNIF)

set(CMAKE_CXX_STANDARD 20)

find_package(PkgConfig REQUIRED) # For pkg-config to locate required libraries
set(DOTNET_SDK_PATH "/usr/local/share/dotnet") # Adjust
set(DOTNET_VERSION "8.0.7") # Adjust

if(APPLE)
    # TODO: Maybe account for intel CPUs? Forget it for now
    set(DOTNET_PLATFORM "osx-arm64") # Adjust
endif()

if(UNIX AND NOT APPLE)
    # for Linux, BSD, Solaris, Minix
    #TODO: This is maybe wrong, fix me
    set(DOTNET_PLATFORM "linux-x64")
endif()


set(DOTNET_SDK_NETHOST "${DOTNET_SDK_PATH}/packs/Microsoft.NETCore.App.Host.${DOTNET_PLATFORM}/${DOTNET_VERSION}/runtimes/${DOTNET_PLATFORM}/native")
set(NETHOST_LIBRARY "${DOTNET_NETHOST_PATH}/libnethost.dylib")
set(DOTNET_HOSTFXR_LIBRARY "${DOTNET_SDK_PATH}/host/fxr/${DOTNET_VERSION}/libhostfxr.dylib")
set(DOTNET_LIBNETHOST_LIBRARY "${DOTNET_SDK_NETHOST}/libnethost.dylib")

message(STATUS "DOTNET_SDK_PATH: ${DOTNET_SDK_PATH}")
message(STATUS "DOTNET_PLATFORM: ${DOTNET_PLATFORM}")
message(STATUS "DOTNET_LIBNETHOST_LIBRARY: ${DOTNET_LIBNETHOST_LIBRARY}")
message(STATUS "DOTNET_HOSTFXR_LIBRARY: ${DOTNET_HOSTFXR_LIBRARY}")

#set(HOSTING_API_LIBS_PATH "${DOTNET_SDK_PATH}/shared/Microsoft.NETCore.App/${DOTNET_VERSION}")  # Replace

include_directories(${DOTNET_SDK_NETHOST})

add_executable(DotBeltNIF main.cpp)

target_link_libraries(DotBeltNIF PUBLIC ${DOTNET_LIBNETHOST_LIBRARY} ${DOTNET_HOSTFXR_LIBRARY})
#target_link_libraries(${PROJECT_NAME} PUBLIC ${DOTNET_SDK_NETHOST})
