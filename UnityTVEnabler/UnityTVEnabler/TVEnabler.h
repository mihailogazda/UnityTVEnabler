//
//  TVEnabler.h
//  UnityTVEnabler
//
//  Created by Mihailo Gazda on 18/11/2016.
//  Copyright © 2016 MihailoGazda. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

@class UnityAppController;



@interface TVEnabler : NSObject

@property (nonatomic, copy) NSString* enabledPath;
@property (nonatomic, retain) UIViewController* viewController;
@property (nonatomic, retain) UnityAppController* appController;

/*
 *  Instance accessor
 */
+ (id) shared;

/*
 *  Starts the enabler app view
 */
- (void) startWith : (UIWindow*) window andAppControler: (NSObject*) appController;



@end
