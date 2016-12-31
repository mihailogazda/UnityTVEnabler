//
//  TVEnabler+Private.h
//  UnityTVEnabler
//
//  Created by Mihailo Gazda on 18/11/2016.
//  Copyright © 2016 MihailoGazda. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "TVEnabler.h"



@interface TVEnabler(TVEnabler_Private)

@property (nonatomic, retain) UnityAppController* appController;

/*
 *  Intializes Unity with correct data path
 */
- (void) initializeUnity;

@end
