//
//  TVLog.h
//  UnityTVEnabler
//
//  Created by Mihailo Gazda on 18/11/2016.
//  Copyright © 2016 MihailoGazda. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface TVLog : NSObject

+ (void) setEnabled: (BOOL) state;
+ (void) info: (NSString*) message;
+ (void) warning: (NSString*) message;
+ (void) error: (NSString*) message;

@end
