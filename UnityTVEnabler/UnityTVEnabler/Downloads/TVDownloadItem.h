//
//  TVDownloadItem.h
//  UnityTVEnabler
//
//  Created by Mihailo Gazda on 18/11/2016.
//  Copyright © 2016 MihailoGazda. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface TVDownloadItem : NSObject

@property (nonatomic, copy) NSURL* url;

- (id) initWithURL : (NSURL*) url;


@end
