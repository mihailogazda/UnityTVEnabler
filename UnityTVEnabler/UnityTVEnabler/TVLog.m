//
//  TVLog.m
//  UnityTVEnabler
//
//  Created by Mihailo Gazda on 18/11/2016.
//  Copyright © 2016 MihailoGazda. All rights reserved.
//

#import "TVLog.h"

@implementation TVLog

static BOOL g_state = YES;
static NSString* TAG_INFO = @"TV-INFO";
static NSString* TAG_WARNING = @"TV-WARNING";
static NSString* TAG_ERROR = @"TV-ERROR";

void printMessage(NSString* tag, NSString* message)
{
    if (g_state)
    {
        NSLog(@"[%@] %@", tag, message);
    }
}

+ (void) setEnabled:(BOOL)state
{
    g_state = state;
}

+ (void) info:(NSString *)message
{
    printMessage(TAG_INFO, message);
}

+ (void) warning:(NSString *)message
{
    printMessage(TAG_WARNING, message);
}

+ (void) error:(NSString *)message
{
    printMessage(TAG_ERROR, message);
}

@end
